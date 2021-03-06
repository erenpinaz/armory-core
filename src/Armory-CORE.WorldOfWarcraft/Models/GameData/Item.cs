using Newtonsoft.Json;
using System.Collections.Generic;

namespace Armory_CORE.Core.WorldOfWarcraft.Models.GameData
{
    public class Item
    {
        [JsonProperty("id")]
        public int Id { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("quality")]
        public TypeCommon Quality { get; internal set; }

        [JsonProperty("level")]
        public int Level { get; internal set; }

        [JsonProperty("required_level")]
        public int RequiredLevel { get; internal set; }

        [JsonProperty("item_class")]
        public ItemClass ItemClass { get; internal set; }

        [JsonProperty("item_subclass")]
        public ItemSubclass ItemSubclass { get; internal set; }

        [JsonProperty("inventory_type")]
        public TypeCommon InventoryType { get; internal set; }

        [JsonProperty("purchase_price")]
        public int PurchasePrice { get; internal set; }

        [JsonProperty("sell_price")]
        public int SellPrice { get; internal set; }

        [JsonProperty("max_count")]
        public int MaxCount { get; internal set; }

        [JsonProperty("is_equippable")]
        public bool IsEquippable { get; internal set; }

        [JsonProperty("is_stackable")]
        public bool IsStackable { get; internal set; }
    }

    public class ItemClassIndex
    {
        [JsonProperty("item_classes")]
        public IEnumerable<ItemClass> ItemClasses { get; internal set; }
    }

    public class ItemClass
    {
        [JsonProperty("id")]
        public int Id { get; internal set; }

        [JsonProperty("class_id")]
        private int ClassId
        {
            set { Id = (value != 0 ? value : Id); }
        }

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("item_subclasses")]
        public IEnumerable<ItemSubclass> ItemSubClasses { get; internal set; }
    }

    public class ItemSubclass
    {
        [JsonProperty("id")]
        public int Id { get; internal set; }

        [JsonProperty("subclass_id")]
        private int SubclassId
        {
            set { Id = (value != 0 ? value : Id); }
        }

        [JsonProperty("class_id")]
        public int ClassId { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("display_name")]
        private string DisplayName
        {
            set { Name = (!string.IsNullOrEmpty(value) ? value : Name); }
        }
    }

    public class ItemSetsIndex
    {
        [JsonProperty("item_sets")]
        public IEnumerable<ItemSet> ItemSets { get; set; }
    }

    public class ItemSet
    {
        [JsonProperty("id")]
        public int Id { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("items")]
        public IEnumerable<Item> Items { get; set; }
    }

    public class ItemMedia : Media { }
}
