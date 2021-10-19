using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ApiVersioningDemo.Configuration
{
    /// <summary>
    /// Versioning extensions class
    /// </summary>
    public static class VersioningExtension
    {
        /// <summary>
        /// Customize the Api versioning
        /// </summary>
        /// <param name="services">the services collection</param>
        public static void AddCustomizedVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(
                options =>
                {
                    // When this property is set to true, the HTTP headers "api-supported-versions" and "api-deprecated-versions" will be added to all valid service routes.
                    options.ReportApiVersions = true;
                });

            services.AddVersionedApiExplorer(
                options =>
                {
                    // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                    // note: the specified format code will format the version as "'v'major[.minor][-status]"
                    options.GroupNameFormat = "'v'VVV";
                    // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                    // can also be used to control the format of the API version in route templates
                    options.SubstituteApiVersionInUrl = true;
                });
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>();
            services.AddSwaggerGen(
                options =>
                {
                    options.IncludeXmlComments(XmlCommentsFilePath);
                });
        }

        /// <summary>
        /// The path for documentation file
        /// </summary>
        private static string XmlCommentsFilePath
        {
            get
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                return xmlPath;
            }
        }
    }
}