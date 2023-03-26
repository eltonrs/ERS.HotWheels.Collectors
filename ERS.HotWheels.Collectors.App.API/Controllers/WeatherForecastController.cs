using ERS.HotWheels.Collectors.Domain.Entities;
using ERS.HotWheels.Collectors.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ERS.HotWheels.Collectors.App.API.Controllers
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
        private readonly IToyCarRepository _toyCarRepository;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IToyCarRepository toyCarRepository
        )
        {
            _logger = logger;
            _toyCarRepository = toyCarRepository;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet(Name = "ToyCars")]
        public ActionResult<IEnumerable<ToyCar>> GetToyCars()
        {
            var toyCars = _toyCarRepository.GetAll();

            if (!toyCars.Any())
            {
                return BadRequest();
            }

            return Ok(toyCars);
        }
    }
}