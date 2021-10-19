using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiVersioningDemo.Controllers.vAll
{
    /// <summary>
    /// It inherits all the versions from LimitedRangeVersionedBaseController
    /// It is a workaround, but try to avoid it. Understand and use ApiVersionNeutral (See NeutralActorController).
    /// </summary>

    public class MultiSkilledActorController : LimitedRangeVersionedBaseController
    {
        private static readonly string[] HelloArray = {
            "Hello", "Hallo", "Salut", "Bonjour", "Guten tag", "Ola", "Hola", "Konnichiwa", "Salve"
        };

        private readonly ILogger<NeutralActorController> _logger;

        /// <summary>
        /// MultiSkilled controller constructor
        /// </summary>
        /// <param name="logger">The logger</param>
        public MultiSkilledActorController(ILogger<NeutralActorController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get a random sublist of the hello array
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