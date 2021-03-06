using Armory_CORE.Core.Models;
using Armory_CORE.Core.Models.Enums;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Armory_CORE.Core.DependencyInjection
{
    public static class ConfigureCoreServices
    {
        /// <summary>
        /// Adds game and token api named  http clients.
        /// </summary>
        /// <param name="services"></param>
        private static void AddApiHttpClients(this IServiceCollection services)
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip
            };

            // Token api client configuration
            services.AddHttpClient(Enum.GetName(typeof(ClientEnum), 0)).ConfigureHttpClient(options =>
            {
                options.DefaultRequestHeaders.Clear();
                options.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }).ConfigurePrimaryHttpMessageHandler(() => handler);

            // Game api client configuration
            services.AddHttpClient(Enum.GetName(typeof(ClientEnum), 1)).ConfigureHttpClient(options =>
            {
                options.DefaultRequestHeaders.Clear();
                options.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }).ConfigurePrimaryHttpMessageHandler(() => handler);
        }

        /// <summary>
        /// Adds base blizzard api services (Prerequisite for game-specific api services).
        /// </summary>
        /// <param name="services"></param>
        /// <param name="region"></param>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="locale"></param>
        /// <param name="useCache"></param>
        /// <param name="cacheDuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddBaseApiServices(this IServiceCollection services, RegionEnum region, string clientId, string clientSecret,
            LocaleEnum? locale = null, bool? useCache = null, long? cacheDuration = null)
        {
            // Register named http clients (Game, Token)
            services.AddApiHttpClients();

            // Register LazyCache - makes the IAppCache implementation
            services.AddLazyCache();

            // Register services
            services.TryAddSingleton(q => new ApiConfiguration(region, clientId, clientSecret, locale, useCache, cacheDuration));
            services.TryAddSingleton<ApiClient>();

            return services;
        }
    }
}
