using System;
using System.Collections.Generic;
using System.Linq;
using ApiVersioningDemo.Models.v1_1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiVersioningDemo.Controllers.v1_2
{
    /// <summary>
    /// WeatherForecast class
    /// If the ApiVersion is superseeded by another version switch the Deprecated property to true
    /// </summary>
    [ApiController]
    [ApiVersion("1.2", Deprecated = true)]
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
        /// <remarks>The method does not need to be explicitly decorated with <b>[MapToApiVersion("1.2")]</b>.<br /> It inherits the attribute from the class level
        /// <br />Being a minor version it uses the same model of v1.1
        /// <br />The class level version is annotated as Deprecated but the method is not marked as Obsolete</remarks>
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
                Summary = BaseWeatherForecastController.Summaries[rng.Next(BaseWeatherForecastController.Summaries.Length)]
            })
            .ToArray();
        }
    }
}
