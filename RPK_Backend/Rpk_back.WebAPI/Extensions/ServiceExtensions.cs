using Microsoft.Extensions.DependencyInjection;
using Rpk_back.Application.Repository;
using Rpk_back.Application.Repository.Implementation;
using Rpk_back.Application.Repository.Interface;
using Rpk_back.Application.Service;
using Rpk_back.Application.Service.Implementation;
using Rpk_back.Application.Service.Interface;

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