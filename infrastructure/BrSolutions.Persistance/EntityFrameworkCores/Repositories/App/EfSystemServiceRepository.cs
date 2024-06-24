using BrSolution.Application.Repositories.App;
using BrSolution.Domain.Entities.App;
using Microsoft.EntityFrameworkCore;

namespace BrSolutions.Persistance.EntityFrameworkCores.Repositories.App;

public class EfSystemServiceRepository : EfRepository<SystemService>, ISystemServiceRepository
{
    public EfSystemServiceRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public async Task<ISet<string>> GetSystemServiceEncryptedNamesAsync()
    {
        return (await Entities.Select(x => x.EncryptedName).ToListAsync()).ToHashSet();
    }
}
