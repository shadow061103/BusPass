using BusPass.Repository.Infrastructure.Helpers;
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
    public static class DependencyInjectionExtension
    {
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

            // Services
            AddServiceRegister(services);

            // Repository
            AddRepositoryRegister(services);
            return services;
        }

        private static void AddRepositoryRegister(IServiceCollection services)
        {
        }

        private static void AddServiceRegister(IServiceCollection services)
        {
        }
    }
}