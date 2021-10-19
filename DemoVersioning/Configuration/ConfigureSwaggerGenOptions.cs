using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ApiVersioningDemo.Configuration
{
    /// <summary>
    /// Helper class for configuring the OpenApiInfo content for each version
    /// </summary>
    public class ConfigureSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        /// <summary>
        /// Custom Swagger Configurator constructor
        /// </summary>
        /// <param name="provider"></param>
        public ConfigureSwaggerGenOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        /// <inheritdoc />
        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateOpenApiInfo(description));
            }
        }

        /// <summary>
        /// Internal implementation for building the Swagger basic config
        /// </summary>
        /// <param name="description">The description object containing the API version.</param>
        /// <returns>Open API Info Object, providing the metadata about the Open API</returns>
        private static OpenApiInfo CreateOpenApiInfo(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Title = "Sample API with versioning Demo",
                Version = description.ApiVersion.ToString(),
                Description = @"<p>Note: For more info on Aspnet api versioning check <a href=""https://github.com/microsoft/aspnet-api-versioning"">this page</a>.</p>",
                Contact = new OpenApiContact
                {
                    Name = "Cognizant Softvision",
                    Email = "info@softvision.com"
                }
            };
            if (description.IsDeprecated)
            {
                info.Description += @"<p><strong>VERSION IS DEPRECATED</strong></p>";
            }
            return info;
        }

    }
}