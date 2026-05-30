using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scaffold.Api.Core.Services.Interface;
using System.Security.Claims;

namespace Scaffold.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]  // Requires valid JWT token
    public class WeatherForecastController(IWeatherForecastService weatherForecastService) : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForeCastService = weatherForecastService;

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            // Get user info from JWT token claims
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;

            return Ok(new
            {
                user = new { userId, email },
                forecast = _weatherForeCastService.GetWeatherForecasts()
            });
        }
    }
}
