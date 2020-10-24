using Microsoft.Extensions.DependencyInjection;
using Rpk_back.Application.Interfaces;
using Rpk_back.Application.Repository;
using Rpk_back.Application.Service;

namespace Rpk_back.WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterRepositoriesAndServices(this IServiceCollection services)
        {
            return services.AddScoped<ISensorRepository, SensorRepository>().AddScoped<ISensorService, SensorService>();
        }
    }
}