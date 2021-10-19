using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace ApiVersioningDemo.Controllers
{
    /// <summary>
    /// Base class for all versioned controllers of WeatherForecast
    /// </summary>
    public abstract class BaseWeatherForecastController : ControllerBase
    {
        /// <summary>
        /// Common property for all derived classes
        /// </summary>
        protected static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        /// <summary>
        /// Logger
        /// </summary>
        protected readonly ILogger<BaseWeatherForecastController> _logger;

        /// <summary>
        /// Base WeatherForecast controller constructor
        /// </summary>
        /// <param name="logger">The logger</param>
        protected BaseWeatherForecastController(ILogger<BaseWeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Sample logging with called version
        /// </summary>
        /// <param name="version"></param>
        protected void Log(ApiVersion version)
        {
            _logger.Log(LogLevel.Information,
                $"Version {version.MajorVersion??0}.{version.MinorVersion??0} was called");
        }
    }
}