using System;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioningDemo.Configuration
{
    /// <summary>
    /// Allows inheriting the versions from the base class
    /// Just as demo. A cleaner approach is to use ApiVersionNeutral
    /// Todo: Stop inheritance to only a single level depth
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class ApiInheritableVersionAttribute : ApiVersionAttribute
    {
        protected ApiInheritableVersionAttribute(ApiVersion version) : base(version)
        {
        }

        public ApiInheritableVersionAttribute(string version) : base(version)
        {
        }
    }
}