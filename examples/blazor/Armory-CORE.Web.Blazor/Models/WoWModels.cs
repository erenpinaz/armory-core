using System.Collections.Generic;

namespace Armory_CORE.Web.Blazor.Models
{
    public enum EquipmentSlot
    {
        HEAD,
        NECK,
        SHOULDER,
        BACK,
        CHEST,
        SHIRT,
        TABARD,
        WRIST,
        HANDS,
        WAIST,
        LEGS,
        FEET,
        FINGER_1,
        FINGER_2,
        TRINKET_1,
        TRINKET_2,
        MAIN_HAND,
        OFF_HAND
    }

    public class EnchantmentModel
    {
        public string DisplayString { get; internal set; }
    }

    public class SocketModel
    {
        public string SocketType { get; internal set; }
        public string Name { get; internal set; }
        public string DisplayString { get; internal set; }
        public string Icon { get; internal set; }
    }

    public class EquipmentModel
    {
        public EquipmentSlot Slot { get; internal set; }
        public string Name { get; internal set; }
        public string Quality { get; internal set; }
        public int Level { get; internal set; }
        public string Transmog { get; internal set; }
        public string Icon { get; internal set; }

        public IEnumerable<SocketModel> Sockets { get; internal set; }
        public IEnumerable<EnchantmentModel> Enchantments { get; internal set; }
    }

    public class GuildModel
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
    }

    public class CharacterModel
    {
        public string DisplayName { get; internal set; }
        public string Title { get; internal set; }
        public string Description { get; internal set; }
        public string FactionImageUrl { get; internal set; }
        public string RealmName { get; internal set; }
        public int AchievementPoints { get; internal set; }
        public int ItemLevel { get; internal set; }
        public string LastLogin { get; internal set; }

        public GuildModel Guild { get; set; }
        public IEnumerable<EquipmentModel> Equipment { get; set; }
    }

    public class SummaryModel
    {
        public string AvatarUrl { get; internal set; }
        public string BustUrl { get; internal set; }
        public string RenderUrl { get; internal set; }

        public CharacterModel Character { get; internal set; }
    }
}
