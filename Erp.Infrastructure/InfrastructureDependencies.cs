using Microsoft.Extensions.DependencyInjection;
using Name.Infrastructure.Bases;

namespace Name.Infrastructure
{
    public static class InfrastructureDependencies
    {

        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {







            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}
