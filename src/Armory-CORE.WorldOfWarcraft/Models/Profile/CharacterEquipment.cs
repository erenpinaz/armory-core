using Newtonsoft.Json;
using System.Collections.Generic;

namespace Armory_CORE.Core.WorldOfWarcraft.Models.Profile
{
    public class CharacterEquipmentSummary
    {
        [JsonProperty("_links")]
        public Links Links { get; internal set; }

        [JsonProperty("character")]
        public Character Character { get; internal set; }

        [JsonProperty("equipped_items")]
        public IEnumerable<EquippedItem> EquippedItems { get; internal set; }

        [JsonProperty("equipped_item_sets")]
        public IEnumerable<EquippedItemSet> EquippedItemSets { get; internal set; }
    }

    public class EquippedItem
    {
        [JsonProperty("item")]
        public KeyCommon ItemKey { get; internal set; }

        [JsonProperty("sockets")]
        public IEnumerable<Socket> Sockets { get; internal set; }

        [JsonProperty("enchantments")]
        public IEnumerable<Enchantment> Enchantments { get; internal set; }

        [JsonProperty("slot")]
        public TypeCommon Slot { get; internal set; }

        [JsonProperty("quantity")]
        public int Quantity { get; internal set; }

        [JsonProperty("context")]
        public int Context { get; internal set; }

        [JsonProperty("bonus_list")]
        public int[] BonusList { get; internal set; }

        [JsonProperty("quality")]
        public TypeCommon Quality { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("description")]
        public string Description { get; internal set; }

        [JsonProperty("modified_appearance_id")]
        public int ModifiedAppearanceId { get; internal set; }

        [JsonProperty("azerite_details")]
        public AzeriteDetails AzeriteDetails { get; internal set; }

        [JsonProperty("media")]
        public KeyCommon MediaKey { get; internal set; }

        [JsonProperty("item_class")]
        public KeyCommon ItemClassKey { get; internal set; }

        [JsonProperty("item_subclass")]
        public KeyCommon ItemSubclassKey { get; internal set; }

        [JsonProperty("inventory_type")]
        public TypeCommon InventoryType { get; internal set; }

        [JsonProperty("binding")]
        public TypeCommon Binding { get; internal set; }

        [JsonProperty("weapon")]
        public Weapon Weapon { get; internal set; }

        [JsonProperty("unique_equipped")]
        public string UniqueEquipped { get; internal set; }

        [JsonProperty("armor")]
        public Armor Armor { get; internal set; }

        [JsonProperty("stats")]
        public IEnumerable<Stat> Stats { get; internal set; }

        [JsonProperty("spells")]
        public IEnumerable<Spell> Spells { get; internal set; }

        [JsonProperty("sell_price")]
        public SellPrice SellPrice { get; internal set; }

        [JsonProperty("requirements")]
        public Requirements Requirements { get; internal set; }

        [JsonProperty("set")]
        public EquippedItemSet Set { get; internal set; }

        [JsonProperty("level")]
        public DisplayCommon<int> Level { get; internal set; }

        [JsonProperty("transmog")]
        public Transmog Transmog { get; internal set; }

        [JsonProperty("durability")]
        public DisplayCommon<int> Durability { get; internal set; }

        [JsonProperty("name_description")]
        public DisplayCommon NameDescription { get; internal set; }

        [JsonProperty("is_subclass_hidden")]
        public bool IsSubclassHidden { get; set; }

        [JsonProperty("is_corrupted")]
        public bool IsCorrupted { get; set; }
    }

    public class AzeriteDetails
    {
        [JsonProperty("percentage_to_next_level")]
        public float PercentageToNextLevel { get; internal set; }

        [JsonProperty("level")]
        public DisplayCommon<int> Level { get; set; }

        [JsonProperty("selected_powers")]
        public IEnumerable<SelectedPower> SelectedPowers { get; internal set; }

        [JsonProperty("selected_essences")]
        public IEnumerable<SelectedEssence> SelectedEssences { get; internal set; }

        [JsonProperty("selected_powers_string")]
        public string SelectedPowersString { get; internal set; }
    }

    public class SelectedPower
    {
        [JsonProperty("id")]
        public int Id { get; internal set; }

        [JsonProperty("tier")]
        public int Tier { get; internal set; }

        [JsonProperty("spell_tooltip")]
        public SpellTooltip SpellTooltip { get; set; }

        [JsonProperty("is_display_hidden")]
        public bool IsDisplayHidden { get; internal set; }
    }

    public class SelectedEssence
    {
        [JsonProperty("slot")]
        public int Slot { get; internal set; }

        [JsonProperty("rank")]
        public int Rank { get; internal set; }

        [JsonProperty("main_spell_tooltip")]
        public SpellTooltip MainSpellTooltip { get; internal set; }

        [JsonProperty("passive_spell_tooltip")]
        public SpellTooltip PassiveSpellTooltip { get; internal set; }

        [JsonProperty("essence")]
        public KeyCommon EssenceKey { get; internal set; }

        [JsonProperty("media")]
        public KeyCommon MediaKey { get; set; }
    }

    public class SpellTooltip
    {
        [JsonProperty("spell")]
        public KeyCommon SpellKey { get; internal set; }

        [JsonProperty("description")]
        public string Description { get; internal set; }

        [JsonProperty("cast_time")]
        public string CastTime { get; internal set; }

        [JsonProperty("cooldown")]
        public string Cooldown { get; internal set; }

        [JsonProperty("range")]
        public string Range { get; internal set; }
    }

    public class Spell
    {
        [JsonProperty("spell")]
        public KeyCommon SpellKey { get; internal set; }

        [JsonProperty("description")]
        public string Description { get; internal set; }

        [JsonProperty("display_color")]
        public Color DisplayColor { get; set; }
    }

    public class Stat
    {
        [JsonProperty("type")]
        public TypeCommon Type { get; internal set; }

        [JsonProperty("value")]
        public int Value { get; internal set; }

        [JsonProperty("display")]
        public DisplayCommon Display { get; internal set; }

        [JsonProperty("is_negated")]
        public bool IsNegated { get; internal set; }

        [JsonProperty("is_equip_bonus")]
        public bool IsEquipBonus { get; internal set; }
    }

    public class Requirements
    {
        [JsonProperty("level")]
        public DisplayCommon<int> Level { get; internal set; }

        [JsonProperty("faction")]
        public DisplayCommon<TypeCommon> Faction { get; internal set; }
    }

    public class Transmog
    {
        [JsonProperty("item")]
        public KeyCommon ItemKey { get; internal set; }

        [JsonProperty("display_string")]
        public string DisplayString { get; internal set; }

        [JsonProperty("item_modified_appearance_id")]
        public int ItemModifiedAppearanceId { get; internal set; }
    }

    public class Armor
    {
        [JsonProperty("value")]
        public int Value { get; internal set; }

        [JsonProperty("display")]
        public DisplayCommon Display { get; internal set; }
    }

    public class SellPrice
    {
        [JsonProperty("value")]
        public int Value { get; internal set; }

        [JsonProperty("display_strings")]
        public SellPriceDisplayStrings DisplayStrings { get; internal set; }
    }

    public class SellPriceDisplayStrings
    {
        [JsonProperty("header")]
        public string Header { get; internal set; }

        [JsonProperty("gold")]
        public int Gold { get; internal set; }

        [JsonProperty("silver")]
        public int Silver { get; internal set; }

        [JsonProperty("bronze")]
        public int Bronze { get; internal set; }
    }

    public class Socket
    {
        [JsonProperty("socket_type")]
        public TypeCommon SocketType { get; internal set; }

        [JsonProperty("item")]
        public KeyCommon ItemKey { get; internal set; }

        [JsonProperty("display_string")]
        public string DisplayString { get; internal set; }

        [JsonProperty("media")]
        public KeyCommon MediaKey { get; internal set; }
    }

    public class Enchantment
    {
        [JsonProperty("enchantment_id")]
        public int Id { get; internal set; }

        [JsonProperty("source_item")]
        public KeyCommon SourceItemKey { get; internal set; }

        [JsonProperty("display_string")]
        public string DisplayString { get; internal set; }

        [JsonProperty("enchantment_slot")]
        public TypeCommon<int> EnchantmentSlot { get; internal set; }
    }

    public class EquippedItemSet
    {
        [JsonProperty("item_set")]
        public KeyCommon ItemSetKey { get; internal set; }

        [JsonProperty("items")]
        public IEnumerable<SetItem> Items { get; internal set; }

        [JsonProperty("effects")]
        public IEnumerable<Effect> Effects { get; internal set; }

        [JsonProperty("display_string")]
        public string DisplayString { get; internal set; }
    }

    public class SetItem
    {
        [JsonProperty("item")]
        public KeyCommon ItemKey { get; internal set; }

        [JsonProperty("is_equipped")]
        public bool IsEquipped { get; internal set; }
    }

    public class Effect
    {
        [JsonProperty("display_string")]
        public string DisplayString { get; internal set; }

        [JsonProperty("required_count")]
        public int RequiredCount { get; internal set; }
    }

    public class Weapon
    {
        [JsonProperty("damage")]
        public Damage Damage { get; internal set; }

        [JsonProperty("attack_speed")]
        public DisplayCommon<int> AttackSpeed { get; internal set; }

        [JsonProperty("dps")]
        public DisplayCommon<float> Dps { get; internal set; }
    }

    public class Damage
    {
        [JsonProperty("min_value")]
        public int MinValue { get; internal set; }

        [JsonProperty("max_value")]
        public int MaxValue { get; internal set; }

        [JsonProperty("display_string")]
        public string DisplayString { get; internal set; }

        [JsonProperty("damage_class")]
        public TypeCommon DamageClass { get; internal set; }
    }
}