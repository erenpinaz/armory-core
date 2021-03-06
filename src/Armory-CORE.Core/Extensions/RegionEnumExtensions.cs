using Armory_CORE.Core.Models.Enums;
using System;

namespace Armory_CORE.Core.Extensions
{
    public static class RegionEnumExtensions
    {
        /// <summary>
        /// Returns default locale for given region.
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        public static LocaleEnum GetDefaultLocale(this RegionEnum region)
        {
            return region switch
            {
                RegionEnum.EU => LocaleEnum.EnglishUK,
                RegionEnum.US => LocaleEnum.EnglishUS,
                RegionEnum.KR => LocaleEnum.Korean,
                RegionEnum.TW => LocaleEnum.Taiwanese,
                _ => LocaleEnum.EnglishUK,
            };
        }

        public static string ToQueryString(this RegionEnum region)
        {
            return ToGameApiUrlPrefix(region);
        }

        /// <summary>
        /// Returns prefix for base game api url.
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        public static string ToGameApiUrlPrefix(this RegionEnum region)
        {
            return region switch
            {
                RegionEnum.EU => "eu",
                RegionEnum.US => "us",
                RegionEnum.KR => "kr",
                RegionEnum.TW => "tw",
                _ => throw new NotImplementedException(nameof(region))
            };
        }

        /// <summary>
        /// Returns prefix for token api url.
        /// KR and TW regions are replaced to APAC (Asia-Pacific).
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        public static string ToTokenApiUrlPrefix(this RegionEnum region)
        {
            return region switch
            {
                RegionEnum.EU => "eu",
                RegionEnum.US => "us",
                RegionEnum.KR => "apac",
                RegionEnum.TW => "apac",
                _ => throw new NotImplementedException(nameof(region))
            };
        }
    }
}