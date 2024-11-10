using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductApi.Domain.Options;

namespace ProductApi.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomainDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStringOptions>(configuration.GetSection(ConnectionStringOptions.SectionName));
            return services;
        }
    }
}
