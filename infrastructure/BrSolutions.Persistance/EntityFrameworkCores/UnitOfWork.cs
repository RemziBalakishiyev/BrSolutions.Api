using BrSolution.Application.Repositories;
using BrSolution.Application.Repositories.App;
using BrSolution.Domain.Entities;
using BrSolutions.Persistance.EntityFrameworkCores.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BrSolutions.Persistance.EntityFrameworkCores;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _dbContext;
    private IDbContextTransaction _transaction;
    private readonly object _locker = new();
    private readonly IDictionary<string, object> _repositoryCache = new Dictionary<string, object>();

    public UnitOfWork()
    {
        _dbContext = new BrSolutionContext();
        _transaction = _dbContext.Database.BeginTransaction();
    }
    public Guid TransactionId => _transaction.TransactionId;

    public IExceptionLogRepository ExceptionLogRepository => GetRepository<IExceptionLogRepository>();

    public async Task SaveChangesAsync(int userId, CancellationToken cancellationToken = default)
    {
        foreach (var entityEntry in _dbContext.ChangeTracker.Entries())
        {
            if (entityEntry.Entity is not IEditedEntity entity)
            {
                continue;
            }

            switch (entityEntry.State)
            {
                case EntityState.Modified:
                    entity.LastEditedDate = DateTime.Now;
                    break;
            }

            switch (entity)
            {
                case ICreatedUserEntity userCreatedEntity
                when entityEntry.State == EntityState.Added:
                    userCreatedEntity.CreatedUserId = userId;
                    break;
                case IEditedRelatableUserEntity userRelatedEntity
                when entityEntry.State == EntityState.Modified:
                    userRelatedEntity.LastEditUserId = userId;
                    break;
            }
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void DiscardChanges()
    {
        _dbContext.ChangeTracker.Clear();
    }

    public async Task RollbackChangesAsync(CancellationToken cancellationToken = default)
    {
        DiscardChanges();
        await _transaction.RollbackAsync(cancellationToken);
        _transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitChangesAsync(CancellationToken cancellationToken = default)
    {
        await _transaction.CommitAsync(cancellationToken);
        DiscardChanges();
        _transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
    }

    public T GetRepository<T>()
    {
        lock (_locker)
        {
            var repoType = typeof(T);
            var repoTypeName = repoType.FullName!;

            if (_repositoryCache.TryGetValue(repoTypeName, out var repo))
            {
                return (T)repo;
            }

            var instance = Activator.CreateInstance(repoType, _dbContext)!;
            _repositoryCache.Add(repoTypeName, instance);

            return (T)instance;
        }
    }

    public void Dispose()
    {
        _transaction.Dispose();
        _dbContext.Dispose();
    }
}
