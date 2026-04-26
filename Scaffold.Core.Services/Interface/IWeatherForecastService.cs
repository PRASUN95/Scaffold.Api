using Scaffold.Api.Core.Services.Models;

namespace Scaffold.Api.Core.Services.Interface
{
    public interface IWeatherForecastService
    {
        List<WeatherForecast> GetWeatherForecasts();
    }
}
