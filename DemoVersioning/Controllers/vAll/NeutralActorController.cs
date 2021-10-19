using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiVersioningDemo.Controllers.vAll
{
    /// <summary>
    /// A version neutral controller. It is exposed on all versions
    /// </summary>
    [ApiController]
    [ApiVersionNeutral]
    [Route("api/v{api-version:apiVersion}/[controller]")]
    public class NeutralActorController : ControllerBase
    {
        private static readonly string[] RadioAlphabet = {
            "Alpha", "Bravo", "Charlie", "Delta", "Echo", "Foxtrot", "Golf", "Hotel", "India", "Juliet"
        };

        private readonly ILogger<NeutralActorController> _logger;

        /// <summary>
        /// Base NeutralActorController controller constructor
        /// </summary>
        /// <param name="logger">The logger</param>
        public NeutralActorController(ILogger<NeutralActorController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get a random sublist of the radio alphabet
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<string> Get(ApiVersion version)
        {
            Log(version);

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => RadioAlphabet[rng.Next(RadioAlphabet.Length)])
                .ToArray();
        }

        private void Log(ApiVersion version)
        {
            _logger.Log(LogLevel.Information,
                $"Version {version.MajorVersion??0}.{version.MinorVersion??0} was called");
        }
    }
}