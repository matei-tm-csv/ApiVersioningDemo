using System;

namespace ApiVersioningDemo.Models.v2_0
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }

        /// <summary>
        /// This property was added on version 2.0
        /// </summary>
        public string ExtraInfo { get; set; }
    }
}
