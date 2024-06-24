using BrSolution.Application.Repositories.App;
using BrSolution.Domain.Entities.App;
using BrSolution.Infrastructure.Helpers;
using BrSolution.Infrastructure.PredefinedValues;
using Microsoft.EntityFrameworkCore;

namespace BrSolutions.Persistance.EntityFrameworkCores.Repositories.App;

public class EfUserRepository(DbContext dbContext)
    : EfRepository<User>(dbContext), IUserRepository
{
    public async Task<bool> IsEmailExistsAsync(string email)
     => await Entities.CountAsync(x => x.Email == email) > 0;

    public async Task<User?> TryToGetWithDetailsAsync(string email, string password)
    {
        var passwordHash = SecurityHelper.ComputeSha256Hash(password);
        var user = await Entities
            .Include(u => u.UserDetail)
            .Include(u => u.UserRoles)
            .ThenInclude(r => r.Role)
            .ThenInclude(r => r.SystemService)
            .SingleOrDefaultAsync(u => u.Email == email
                                            && u.PasswordHash == passwordHash
                                            && u.UserStatusId != UserStatusValue.Deactive);

        return user;
    }
}
