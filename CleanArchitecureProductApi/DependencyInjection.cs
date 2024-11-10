using ProductApi.Application;
using ProductApi.Domain;
using ProductApi.Infrastructure;

namespace CleanArchitecureProductApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiDi(this IServiceCollection services, IConfiguration configuration)
        { 
            services.AddApplicationDI()
                .AddInfrastructureDI(configuration)
                .AddDomainDI(configuration);
            return services;
        }

    }
}
