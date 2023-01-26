using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using GithubIntegration.Facades.Extensions;
using GithubIntegration.Middleware;
using GithubIntegration.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace GithubIntegration
{

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingletons(Configuration);

            AddSwagger(services);

            services.AddControllers(config => config.Filters.Add(new ProducesAttribute("application/json")));

            services.AddHealthChecks();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseSwagger()
               .UseSwaggerUI(c =>
               {
                   c.RoutePrefix = string.Empty;
                   c.SwaggerEndpoint(Constants.SWAGGERFILE_PATH, Constants.PROJECT_NAME + Constants.API_VERSION);
               });

            app.UseHttpsRedirection()
               .UseAuthentication()
               .UseRouting()
               .UseAuthorization()
               .UseHealthChecks("/health")
               .UseEndpoints(endpoints =>
               {
                   endpoints.MapControllers();
               });
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(Constants.API_VERSION, new OpenApiInfo { Title = Constants.PROJECT_NAME, Version = Constants.API_VERSION });
                var xmlFile = Assembly.GetExecutingAssembly().GetName().Name + Constants.XML_EXTENSION;
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}
