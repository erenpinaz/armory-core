using Newtonsoft.Json;
using System;

namespace Armory_CORE.Core.WorldOfWarcraft.Models
{
    public class Links
    {
        [JsonProperty("self")]
        public Self Self { get; internal set; }

        [JsonProperty("key")]
        public Key Key { get; internal set; }
    }

    public class Self
    {
        [JsonProperty("href")]
        public Uri Href { get; internal set; }
    }

    public class Key
    {
        [JsonProperty("href")]
        public Uri Href { get; internal set; }
    }

    public class TypeCommon
    {
        [JsonProperty("type")]
        public string Type { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }
    }

    public class TypeCommon<T> : TypeCommon
    {
        [JsonProperty("id")]
        public T Id { get; internal set; }
    }

    public class DisplayCommon
    {
        [JsonProperty("display_string")]
        public string DisplayString { get; internal set; }

        [JsonProperty("color")]
        public Color Color { get; internal set; }
    }

    public class DisplayCommon<T> : DisplayCommon
    {
        [JsonProperty("value")]
        public T Value { get; internal set; }
    }

    public class Color
    {
        [JsonProperty("r")]
        public byte R { get; internal set; }

        [JsonProperty("g")]
        public byte G { get; internal set; }

        [JsonProperty("b")]
        public byte B { get; internal set; }

        [JsonProperty("a")]
        public double A { get; internal set; }
    }

    public class KeyCommon
    {
        [JsonProperty("key")]
        public Key Key { get; internal set; }

        [JsonProperty("id")]
        public int Id { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }
    }
}
