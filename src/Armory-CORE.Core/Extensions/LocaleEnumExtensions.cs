using Armory_CORE.Core.Models.Enums;
using System;

namespace Armory_CORE.Core.Extensions
{
    public static class LocaleEnumExtensions
    {
        /// <summary>
        /// Returns query string representation of given locale.
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        public static string ToQueryString(this LocaleEnum locale)
        {
            return locale switch
            {
                LocaleEnum.EnglishUK    => "en_GB",
                LocaleEnum.EnglishUS    => "en_US",
                LocaleEnum.French       => "fr_FR",
                LocaleEnum.German       => "de_DE",
                LocaleEnum.Italian      => "it_IT",
                LocaleEnum.Korean       => "ko_KR",
                LocaleEnum.PortugueseBR => "pt_BR",
                LocaleEnum.PortuguesePT => "pt_PT",
                LocaleEnum.Russian      => "ru_RU",
                LocaleEnum.SpanishES    => "es_ES",
                LocaleEnum.SpanishMX    => "es_MX",
                LocaleEnum.Taiwanese    => "zh_TW",
                _ => throw new NotImplementedException(nameof(locale))
            };
        }
    }
}