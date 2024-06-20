using BrSolution.Application.Repositories.App;
using BrSolution.Domain.Entities.App;
using Microsoft.EntityFrameworkCore;

namespace BrSolutions.Persistance.EntityFrameworkCores.Repositories.App;

public class EfExceptionLogRepository : EfRepository<ExceptionLog>, IExceptionLogRepository
{
    public EfExceptionLogRepository(DbContext dbContext) : base(dbContext)
    {
    }
}
