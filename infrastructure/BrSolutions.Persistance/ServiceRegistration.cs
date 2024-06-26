using BrSolution.Application.Repositories;
using BrSolutions.Persistance.EntityFrameworkCores;
using Microsoft.Extensions.DependencyInjection;

namespace BrSolutions.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
