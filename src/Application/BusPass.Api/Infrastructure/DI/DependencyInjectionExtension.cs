using BusPass.Repository.Infrastructure.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using BusPass.Repository.Interfaces;
using BusPass.Repository.Implements;

namespace BusPass.Api.Infrastructure.DI
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
                       AutomaticDecompression = DecompressionMethods.GZip
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
        }

        private static void AddRepositoryRegister(IServiceCollection services)
        {
            services.AddSingleton<IDatabaseHelper, DatabaseHelper>();
            services.AddSingleton<IUrlHelper, UrlHelper>();
            services.AddScoped<ICityBusProxy, CityBusProxy>();
        }

        private static void AddServiceRegister(IServiceCollection services)
        {
        }
    }
}