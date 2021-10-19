using System;

namespace ApiVersioningDemo.Models.v1_1
{
    /// <summary>
    /// The WeatherForecast DTO
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// Date of the forecast
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Temperature on Celsius scale
        /// </summary>
        public int TemperatureC { get; set; }

        /// <summary>
        /// Temperature on Fahrenheit scale
        /// </summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>
        /// The summary of the forecast
        /// <remarks>It will be replaced by extra info</remarks>
        /// </summary>
        [Obsolete("It will be replaced by extra info")]
        public string Summary { get; set; }
    }
}
