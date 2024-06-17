using BrSolution.Application.Repositories.App;
using BrSolution.Domain.Entities.App;
using Microsoft.EntityFrameworkCore;

namespace BrSolutions.Persistance.EntityFrameworkCores.Repositories.App;

public class EfModuleRepository(DbContext dbContext) 
    : EfRepository<Module>(dbContext), IModuleRepository
{

}
