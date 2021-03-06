using Newtonsoft.Json;
using System;

namespace Armory_CORE.Core.WorldOfWarcraft.Models.Profile
{
    public class Character
    {
        [JsonProperty("key")]
        public Key Key { get; internal set; }

        [JsonProperty("id")]
        public int Id { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("realm")]
        public CharacterRealm Realm { get; internal set; }
    }

    public class Achievements
    {
        [JsonProperty("href")]
        public Uri Href { get; internal set; }
    }

    public class ActiveSpec
    {
        [JsonProperty("key")]
        public Key Key { get; internal set; }

        [JsonProperty("id")]
        public int Id { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }
    }

    public class ActiveTitle
    {
        [JsonProperty("key")]
        public Key Key { get; internal set; }

        [JsonProperty("type")]
        public int Id { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("display_string")]
        public string DisplayString { get; set; }
    }

    public class Appearance
    {
        [JsonProperty("href")]
        public Uri Href { get; internal set; }
    }

    public class Collections
    {
        [JsonProperty("href")]
        public Uri Href { get; internal set; }
    }

    public class Equipment
    {
        [JsonProperty("href")]
        public Uri Href { get; internal set; }
    }

    public class Faction
    {
        [JsonProperty("type")]
        public string Type { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }
    }

    public class Gender
    {
        [JsonProperty("type")]
        public string Type { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }
    }

    public class Guild
    {
        [JsonProperty("key")]
        public Key Key { get; internal set; }

        [JsonProperty("id")]
        public int Id { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("realm")]
        public CharacterRealm Realm { get; set; }
    }

    public class MediaUrl
    {
        [JsonProperty("href")]
        public Uri Href { get; internal set; }
    }

    public class MythicKeystoneProfile
    {
        [JsonProperty("href")]
        public Uri Href { get; internal set; }
    }

    public class PvpSummary
    {
        [JsonProperty("href")]
        public Uri Href { get; internal set; }
    }

    public class Race
    {
        [JsonProperty("key")]
        public Key Key { get; internal set; }

        [JsonProperty("type")]
        public int Id { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }
    }

    public class RaidProgression
    {
        [JsonProperty("href")]
        public Uri Href { get; internal set; }
    }

    public class CharacterRealm
    {
        [JsonProperty("key")]
        public Key Key { get; internal set; }

        [JsonProperty("id")]
        public int Id { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("slug")]
        public string Slug { get; internal set; }
    }

    public class Reputations
    {
        [JsonProperty("href")]
        public Uri Href { get; internal set; }
    }

    public class Specializations
    {
        [JsonProperty("href")]
        public Uri Href { get; internal set; }
    }

    public class Statistics
    {
        [JsonProperty("href")]
        public Uri Href { get; internal set; }
    }

    public class Titles
    {
        [JsonProperty("href")]
        public Uri Href { get; internal set; }
    }
}
