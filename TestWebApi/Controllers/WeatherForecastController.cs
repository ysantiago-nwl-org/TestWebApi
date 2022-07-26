using Microsoft.AspNetCore.Mvc;

namespace TestWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
            })
            .ToArray();
        }

        [HttpGet]
        [Route("GetWeatherForecast/{city}")]
        public WeatherForecast GetCityWeatherForecast(string city)
        {
            return new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = Random.Shared.Next(-20, 50),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
            };
        }
    }
}