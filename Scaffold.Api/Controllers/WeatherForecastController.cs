using Microsoft.AspNetCore.Mvc;
using Scaffold.Api.Core.Services.Interface;

namespace Scaffold.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(IWeatherForecastService weatherForecastService) : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForeCastService = weatherForecastService;

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            return Ok(_weatherForeCastService.GetWeatherForecasts());
        }
    }
}
