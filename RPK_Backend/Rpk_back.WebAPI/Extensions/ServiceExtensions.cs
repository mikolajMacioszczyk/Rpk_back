using Microsoft.Extensions.DependencyInjection;
using Rpk_back.Application.Repository;

namespace Rpk_back.WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            return services.AddScoped<ISensorRepository, SensorRepository>();
        }
    }
}