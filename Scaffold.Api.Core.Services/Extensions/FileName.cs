using Microsoft.Extensions.DependencyInjection;
using Scaffold.Api.Core.Services.Interface;
using Scaffold.Api.Core.Services.Services;

namespace Scaffold.Api.Core.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();
            return services;
        }
    }
}
