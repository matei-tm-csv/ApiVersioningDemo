using Microsoft.AspNetCore.Mvc;

namespace ApiVersioningDemo.Controllers
{
    /// <summary>
    /// This class is a single point of changes for controllers that are available on limited range of versions
    /// Warning: Not recommended! Better approach is to use the ApiVersionNeutral
    /// </summary>
    [ApiController]
    [ApiInheritableVersion("1.2")]
    [ApiInheritableVersion("2.0")]
    [Route("api/v{api-version:apiVersion}/[controller]")]
    public abstract class LimitedRangeVersionedBaseController : ControllerBase
    {
    }
}