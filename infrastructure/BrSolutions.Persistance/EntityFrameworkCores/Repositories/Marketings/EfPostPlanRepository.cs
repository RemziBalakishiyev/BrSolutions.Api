using BrSolution.Application.Repositories.Marketings;
using BrSolution.Domain.Entities.Marketing;
using Microsoft.EntityFrameworkCore;

namespace BrSolutions.Persistance.EntityFrameworkCores.Repositories.Marketings;

public class EfPostPlanRepository(DbContext dbContext)
    : EfRepository<PostPlan>(dbContext), IPostPlanRepository
{
}
