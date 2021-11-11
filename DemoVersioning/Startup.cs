using ApiVersioningDemo.Configuration;
using ApiVersioningDemo.Controllers.v3_0;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;

namespace ApiVersioningDemo
{
    /// <summary>
    /// The Startup class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configuration read-only property
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Startup process of the application
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configure services
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The services collection</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCustomizedVersioning();

            services.AddApiVersioning(options =>
            {
                options.Conventions.Controller<WeatherForecastController>().HasApiVersion(3, 0);
            });

        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The app builder</param>
        /// <param name="env">The web host environment</param>
        /// <param name="provider">The api version description provider</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });
        }
    }
}
