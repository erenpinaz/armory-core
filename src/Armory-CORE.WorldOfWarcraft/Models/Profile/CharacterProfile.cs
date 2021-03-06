using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Armory_CORE.Core.WorldOfWarcraft.Models.Profile
{
    public class CharacterProfileSummary
    {
        [JsonProperty("_links")]
        public Links Links { get; internal set; }

        [JsonProperty("id")]
        public int Id { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("gender")]
        public Gender Gender { get; internal set; }

        [JsonProperty("faction")]
        public Faction Faction { get; internal set; }

        [JsonProperty("race")]
        public Race Race { get; internal set; }

        [JsonProperty("character_class")]
        public KeyCommon Class { get; internal set; }

        [JsonProperty("active_spec")]
        public ActiveSpec ActiveSpec { get; internal set; }

        [JsonProperty("realm")]
        public CharacterRealm Realm { get; internal set; }

        [JsonProperty("guild")]
        public Guild Guild { get; internal set; }

        [JsonProperty("level")]
        public int Level { get; internal set; }

        [JsonProperty("experience")]
        public int Experience { get; internal set; }

        [JsonProperty("achievement_points")]
        public int AchievementPoints { get; internal set; }

        [JsonProperty("achievements")]
        public Achievements Achievements { get; internal set; }

        [JsonProperty("titles")]
        public Titles Titles { get; internal set; }

        [JsonProperty("pvp_summary")]
        public PvpSummary PvpSummary { get; internal set; }

        [JsonProperty("raid_progression")]
        public RaidProgression RaidProgression { get; internal set; }

        [JsonProperty("media")]
        public MediaUrl Media { get; internal set; }

        [JsonProperty("last_login_timestamp")]
        [JsonConverter(typeof(MillisecondEpochConverter))]
        public DateTime LastLogin { get; internal set; }

        [JsonProperty("average_item_level")]
        public int AverageItemLevel { get; internal set; }

        [JsonProperty("equipped_item_level")]
        public int EquippedItemLevel { get; internal set; }

        [JsonProperty("specializations")]
        public Specializations Specializations { get; internal set; }

        [JsonProperty("statistics")]
        public Statistics Statistics { get; internal set; }

        [JsonProperty("mythic_keystone_profile")]
        public MythicKeystoneProfile MythicKeystoneProfile { get; internal set; }

        [JsonProperty("equipment")]
        public Equipment Equipment { get; internal set; }

        [JsonProperty("appearance")]
        public Appearance Appearance { get; internal set; }

        [JsonProperty("collections")]
        public Collections Collections { get; internal set; }

        [JsonProperty("active_title")]
        public ActiveTitle ActiveTitle { get; internal set; }

        [JsonProperty("reputations")]
        public Reputations Reputations { get; internal set; }
    }

    public class CharacterProfileStatus
    {
        [JsonProperty("_links")]
        public Links Links { get; internal set; }

        [JsonProperty("id")]
        public int Id { get; internal set; }

        [JsonProperty("id_valid")]
        public bool IsValid { get; internal set; }
    }

    /// <summary>
    /// Converts timestamp in milliseconds to datetime.
    /// </summary>
    public class MillisecondEpochConverter : DateTimeConverterBase
    {
        private static readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue(((DateTime)value - _epoch).TotalMilliseconds.ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null) { return null; }
            return _epoch.AddMilliseconds((long)reader.Value);
        }
    }
}
