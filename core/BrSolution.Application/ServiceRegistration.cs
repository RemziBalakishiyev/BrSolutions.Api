using BrSolution.Application.ServiceImplementations.App;
using BrSolution.Application.ServiceInterfaces.App;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BrSolution.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddAutoMapper(assembly);
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));


            foreach (var exportedType in assembly.ExportedTypes)
            {
                //init validators
                if ((exportedType.BaseType?.IsGenericType ?? false)
                    && exportedType.BaseType.GetGenericTypeDefinition() == typeof(AbstractValidator<>))
                {
                    services.AddSingleton(exportedType.BaseType, exportedType);
                }
            }

        }
    }
}
