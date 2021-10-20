using System;
using System.Collections.Generic;
using System.Linq;
using ApiVersioningDemo.Configuration;
using ApiVersioningDemo.Controllers.vAll;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiVersioningDemo.Controllers.vSome
{
    /// <summary>
    /// Implementation with custom attribute for versions range
    /// </summary>

    [ApiController]
    [ApiRangeV1m2V2m0]
    [Route("api/v{api-version:apiVersion}/[controller]")]
    public class SafeSkilledActorController
    {
        private static readonly string[] HelloArray = {
            "Hello!", "Hallo!", "Salut!", "Bonjour!", "Guten tag!", "Ola!", "Hola!", "Konnichiwa!", "Salve!"
        };

        private readonly ILogger<NeutralActorController> _logger;

        /// <summary>
        /// SafeSkilled controller constructor
        /// </summary>
        /// <param name="logger">The logger</param>
        public SafeSkilledActorController(ILogger<NeutralActorController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get a random sublist of the hello array with an exclamation mark
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<string> Get(ApiVersion version)
        {
            Log(version);

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => HelloArray[rng.Next(HelloArray.Length)])
                .ToArray();
        }

        private void Log(ApiVersion version)
        {
            _logger.Log(LogLevel.Information,
                $"Version {version.MajorVersion??0}.{version.MinorVersion??0} was called");
        }
    }
}