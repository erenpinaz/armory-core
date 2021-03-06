using Armory_CORE.Core.Extensions;
using Armory_CORE.Core.Models.Enums;

namespace Armory_CORE.Core.Models
{
    public class ApiConfiguration
    {
        private const string API_URL_BASE = "https://{0}.api.blizzard.com";
        private const string TOKEN_API_URL_BASE = "https://{0}.battle.net/oauth/token";

        public string ClientId { get; }
        public string ClientSecret { get; }
        public RegionEnum Region { get; }
        public LocaleEnum Locale { get; }
        public bool UseCache { get; }
        public long CacheDuration { get; }

        public ApiConfiguration(RegionEnum region, string clientId, string clientSecret, LocaleEnum? locale = null, bool? useCache = null, long? cacheDuration = null)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            Region = region;
            Locale = locale ?? region.GetDefaultLocale();
            UseCache = useCache ?? false;
            CacheDuration = cacheDuration ?? 0;
        }

        public string GetGameApiUrl(RegionEnum region)
        {
            return string.Format(API_URL_BASE, region.ToGameApiUrlPrefix());
        }

        public string GetTokenApiUrl(RegionEnum region)
        {
            return string.Format(TOKEN_API_URL_BASE, region.ToTokenApiUrlPrefix());
        }
    }
}
