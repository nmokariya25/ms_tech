using Consul_Impl.Helpers;
using Consul_Impl.Models;
using Microsoft.AspNetCore.Mvc;

namespace Consul_Impl.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<ActionResult> Get()
        {
            var consulDemoKey = await ConsulKeyValueProvider.GetValueAsync<ConsulDemoKey>(key: "ConsulDemoKey");

            if (consulDemoKey != null && consulDemoKey.IsEnabled)
            {
                return Ok(consulDemoKey);
            }

            return Ok("ConsulDemoKey is null");
        }
    }
}