using Armory_CORE.Core.Models.Enums;
using System.Collections.Generic;

namespace Armory_CORE.Core.Models
{
    public class RequestOptions
    {
        public RegionEnum? Region { get; internal set; }
        public LocaleEnum? Locale { get; internal set; }
        public bool UseRegionLocale { get; internal set; }
        public bool? UseCache { get; internal set; }
        public long? CacheDuration { get; internal set; }
        public IDictionary<string, string> QueryParams { get; internal set; }

        /// <summary>
        /// Used to override api configuration values while sending requests.
        /// </summary>
        public RequestOptions(RegionEnum? region = null, LocaleEnum? locale = null, bool useRegionLocale = false, bool? useCache = null, long? cacheDuration = null, Dictionary<string, string> queryParams = null)
        {
            Region = region;
            Locale = locale;
            UseCache = useCache;
            CacheDuration = cacheDuration;
            UseRegionLocale = useRegionLocale;
            QueryParams = queryParams;
        }
    }
}
