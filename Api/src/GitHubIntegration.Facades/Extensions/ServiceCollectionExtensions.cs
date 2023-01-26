using System;
using System.Collections.Generic;
using GithubIntegration.Facades.Strategies.ExceptionHandlingStrategies;
using GithubIntegration.Models.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestEase;
using GithubIntegration.Services.Atlassian.Interface;
using GithubIntegration.Facades.Github.Interfaces;
using GithubIntegration.Facades.Github;
using GithubIntegration.Models;

namespace GithubIntegration.Facades.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers project's specific services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddSingletons(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.GetSection(Constants.SETTINGS_SECTION).Get<ApiSettings>();

            services.AddSingleton(settings);

            services.AddRestServices(settings);

            services.AddSingleton(provider =>
            {
                return new Dictionary<Type, ExceptionHandlingStrategy>
                {
                    { typeof(ApiException), new ApiExceptionHandlingStrategy() },
                    { typeof(NotImplementedException), new NotImplementedExceptionHandlingStrategy() }
                };
            });

            services.AddSingleton<IGithubFacade, GithubFacade>();

    }

    private static IServiceCollection AddRestServices(this IServiceCollection services, ApiSettings settings)
        {

            services.AddSingleton(request =>
            {
                var githubService = RestClient.For<IRequestGithubService>(settings.GithubSettings.Base_Url);
                return githubService;
            });

            return services;
        }
    }
}
