using BrSolution.Domain.Entities.App;

namespace BrSolution.Application.Repositories.App;

public interface ISystemServiceRepository : IRepository<SystemService>
{
    Task<ISet<string>> GetSystemServiceEncryptedNamesAsync();
}
