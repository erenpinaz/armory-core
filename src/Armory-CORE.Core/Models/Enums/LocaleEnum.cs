using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Armory_CORE.Core.Models.Enums
{
    public enum LocaleEnum
    {
        [Display(Name = "English (US)")]
        [Description("en_US")]
        EnglishUS,

        [Display(Name = "Spanish (MX)")]
        [Description("es_MX")]
        SpanishMX,

        [Display(Name = "Portuguese (BR)")]
        [Description("pt_BR")]
        PortugueseBR,

        [Display(Name = "English (GK)")]
        [Description("en_GB")]
        EnglishUK,

        [Display(Name = "Spanish (ES)")]
        [Description("es_ES")]
        SpanishES,

        [Display(Name = "French")]
        [Description("fr_FR")]
        French,

        [Display(Name = "Russian")]
        [Description("ru_RU")]
        Russian,

        [Display(Name = "German")]
        [Description("de_DE")]
        German,

        [Display(Name = "Portuguese (PT)")]
        [Description("pt_PT")]
        PortuguesePT,

        [Display(Name = "Italian")]
        [Description("it_IT")]
        Italian,

        [Display(Name = "Korean")]
        [Description("ko_KR")]
        Korean,

        [Display(Name = "Taiwanese")]
        [Description("zh_TW")]
        Taiwanese
    }
}
