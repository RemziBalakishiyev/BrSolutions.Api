using BrSolution.Application.Repositories.App;
using BrSolution.Domain.Entities.App;
using Microsoft.EntityFrameworkCore;

namespace BrSolutions.Persistance.EntityFrameworkCores.Repositories.App;

public class EfUserRepository(DbContext dbContext) 
    : EfRepository<User>(dbContext), IUserRepository
{
}
