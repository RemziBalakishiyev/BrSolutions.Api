using BrSolution.Application.Repositories.App;
using BrSolution.Domain.Entities.App;
using Microsoft.EntityFrameworkCore;

namespace BrSolutions.Persistance.EntityFrameworkCores.Repositories.App
{
    public class EfUserRoleRepository : EfRepository<UserRole>, IUserRoleRepository
    {
        public EfUserRoleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
