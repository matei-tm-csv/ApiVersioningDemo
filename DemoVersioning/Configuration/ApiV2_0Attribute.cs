using System;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioningDemo.Configuration
{
    /// <summary>
    /// A V2.0 fixed version attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public sealed class ApiV2_0Attribute : ApiVersionAttribute
    {
        public ApiV2_0Attribute() : base("2.0")
        {
        }
    }
}