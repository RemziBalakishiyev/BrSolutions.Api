using BrSolution.Application.Repositories.App;

namespace BrSolution.Application.Repositories;

public interface IUnitOfWork : IDisposable
{
    public IExceptionLogRepository ExceptionLogRepository { get; }
    public ISystemServiceRepository SystemServiceRepository { get; }
    public IUserRepository UserRepository { get; }
    public IUserRoleRepository UserRoleRepository { get; }
    public IRoleRepository RoleRepository { get; }
    Guid TransactionId { get; }

    Task SaveChangesAsync(int userId, CancellationToken cancellationToken = default);

    void DiscardChanges();

    Task RollbackChangesAsync(CancellationToken cancellationToken = default);

    Task CommitChangesAsync(CancellationToken cancellationToken = default);
}

