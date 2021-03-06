using Armory_CORE.Core.Extensions;
using Armory_CORE.Core.Models;
using Armory_CORE.Core.Models.Enums;
using LazyCache;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Armory_CORE.Core
{
    public class ApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IAppCache _cache;
        private readonly ApiConfiguration _defaultApiConfiguration;

        private readonly HttpClient _tokenClient;
        private readonly HttpClient _gameApiClient;

        public ApiClient(IHttpClientFactory httpClientFactory, IAppCache cache, ApiConfiguration defaultApiConfiguration)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _defaultApiConfiguration = defaultApiConfiguration ?? throw new ArgumentNullException(nameof(defaultApiConfiguration));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));

            _tokenClient = _httpClientFactory.CreateClient(Enum.GetName(typeof(ClientEnum), 0));
            _gameApiClient = _httpClientFactory.CreateClient(Enum.GetName(typeof(ClientEnum), 1));
        }

        /// <summary>
        /// Requests data for current region from game api.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUri"></param>
        /// <param name="namespace"></param>
        /// <param name="requestOptions"></param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(string requestUri, string @namespace, RequestOptions requestOptions = null)
        {
            // Use default region and locale if not specified in request scope
            var region = requestOptions?.Region ?? _defaultApiConfiguration.Region;
            var locale = requestOptions.UseRegionLocale 
                ? region.GetDefaultLocale() 
                : (requestOptions?.Locale ?? _defaultApiConfiguration.Locale);
            var useCache = requestOptions?.UseCache ?? _defaultApiConfiguration.UseCache;
            var cacheDuration = requestOptions?.CacheDuration ?? _defaultApiConfiguration.CacheDuration;

            // Refresh token
            var token = await RequestTokenAsync(region);

            // Build query string
            var queryParams = requestOptions?.QueryParams ?? new Dictionary<string, string>();
            queryParams.Add("locale", locale.ToQueryString());
            if (!string.IsNullOrEmpty(@namespace)) queryParams.Add("namespace", $"{@namespace}-{region.ToQueryString()}");

            var finalUri = QueryHelpers.AddQueryString($"{_defaultApiConfiguration.GetGameApiUrl(region)}{requestUri}", queryParams);

            // Setup request authorization
            _gameApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);

            // Send request
            var response = useCache ? await _cache.GetAsync<string>(finalUri) : null;
            if (response == null)
            {
                using var responseMessage = await _gameApiClient.GetAsync(finalUri);
                responseMessage.EnsureSuccessStatusCode();

                response = await responseMessage.Content.ReadAsStringAsync();

                if (useCache)
                {
                    _cache.Add(finalUri, response, TimeSpan.FromSeconds(cacheDuration));
                }
            }

            // Return response
            return JsonConvert.DeserializeObject<T>(response);
        }

        /// <summary>
        /// Requests access token for current region from token api.
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        private async Task<Token> RequestTokenAsync(RegionEnum region)
        {
            // Request new token if token is not cached
            var token = await _cache.GetOrAddAsync($"token-{region.ToQueryString()}", async q =>
            {
                // Build token request parameters
                var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>> {
                        new KeyValuePair<string, string>("grant_type", "client_credentials")
                });

                // Setup client credentials authorization
                _tokenClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_defaultApiConfiguration.ClientId}:{_defaultApiConfiguration.ClientSecret}"))
                );

                using var response = await _tokenClient.PostAsync(_defaultApiConfiguration.GetTokenApiUrl(region), content);
                response.EnsureSuccessStatusCode();

                var tokenJson = await response.Content.ReadAsStringAsync();
                var tokenObject = JsonConvert.DeserializeObject<Token>(tokenJson);

                q.SetAbsoluteExpiration(TimeSpan.FromSeconds(tokenObject.Expiration));

                return tokenObject;
            });

            return token;
        }
    }
}
