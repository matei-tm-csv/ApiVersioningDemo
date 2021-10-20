using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace ApiVersioningDemo.Configuration
{
    /// <summary>
    /// Fixed range versioning
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class ApiRangeV1m2V2m0Attribute : ApiVersionsBaseAttribute, IApiVersionProvider
    {
        public ApiRangeV1m2V2m0Attribute():base("1.2", "2.0")
        {
                
        }

        /// <summary>
        /// Provider Options
        /// </summary>
        public ApiVersionProviderOptions Options => ApiVersionProviderOptions.Mapped;
    }
}