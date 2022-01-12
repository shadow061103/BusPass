using BusPass.Repository.Infrastructure.Helpers;
using BusPass.Task.Interfaces;
using BusPass.Task.Jobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BusPass.Task.Infrastructure.DI
{
    /// <summary>
    /// DI
    /// </summary>
    public static class DependencyInjectionExtension
    {
        /// <summary>
        /// Adds the dependency injection.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services,
                                                               IConfiguration configuration)
        {
            services.AddHttpClient("PFX")
               .ConfigurePrimaryHttpMessageHandler
           (
                   () => new HttpClientHandler
                   {
                       UseDefaultCredentials = true,
                       DefaultProxyCredentials = CredentialCache.DefaultNetworkCredentials,
                   }
           );

            services.AddSingleton<IApiHelper, ApiHelper>();

            //Applicaiton
            AddApplicationDependencyInjection(services);

            // Services
            AddServiceRegister(services);

            // Repository
            AddRepositoryRegister(services);
            return services;
        }

        private static void AddApplicationDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IJobTrigger, JobTrigger>();
        }

        private static void AddRepositoryRegister(IServiceCollection services)
        {
            services.AddSingleton<IDatabaseHelper, DatabaseHelper>();
            services.AddSingleton<IUrlHelper, UrlHelper>();
        }

        private static void AddServiceRegister(IServiceCollection services)
        {
        }
    }
}