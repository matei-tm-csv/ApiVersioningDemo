using System;
using System.Collections.Generic;
using System.Linq;
using ApiVersioningDemo.Models.v2_0;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiVersioningDemo.Controllers.v2_0
{
    /// <summary>
    /// WeatherForecast class
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{api-version:apiVersion}/[controller]")]
    public class WeatherForecastController : BaseWeatherForecastController
    {
        /// <summary>
        /// WeatherForecast constructor
        /// </summary>
        /// <param name="logger">logger</param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger) : base(logger)
        {
        }

        /// <summary>
        /// Get the weather forecast (Expand to see remarks)
        /// </summary>
        /// <remarks>The method does not need to be explicitly decorated with <b>[MapToApiVersion("2.0")]</b>.<br /> It inherits the attribute from the class level</remarks>
        /// <param name="version">The version parameter</param>
        /// <returns>A collection of WeatherForecast</returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> Get(ApiVersion version)
        {
            Log(version);

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)],
                ExtraInfo = "some extra info " + Summaries[rng.Next(Summaries.Length)].Length
            })
                .ToArray();
        }


    }
}
