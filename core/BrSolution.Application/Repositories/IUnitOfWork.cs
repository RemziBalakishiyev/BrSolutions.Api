namespace BrSolution.Application.Repositories;

public interface IUnitOfWork : IDisposable
{
    Guid TransactionId { get; }

    Task SaveChangesAsync(int userId, CancellationToken cancellationToken = default);

    void DiscardChanges();

    Task RollbackChangesAsync(CancellationToken cancellationToken = default);

    Task CommitChangesAsync(CancellationToken cancellationToken = default);
}

