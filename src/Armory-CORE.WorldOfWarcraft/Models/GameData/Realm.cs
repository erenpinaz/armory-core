using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Armory_CORE.Core.WorldOfWarcraft.Models.GameData
{
    public class RealmIndex
    {
        [JsonProperty("_links")]
        public Links Links { get; internal set; }

        [JsonProperty("realms")]
        public IEnumerable<Realm> Realms { get; internal set; }
    }

    public class Realm
    {
        [JsonProperty("key")]
        public Key Key { get; internal set; }

        [JsonProperty("_links")]
        public Links Links { get; internal set; }

        [JsonProperty("id")]
        public int Id { get; internal set; }

        [JsonProperty("region")]
        public Region Region { get; internal set; }

        [JsonProperty("connected_realm")]
        public ConnectedRealmUrl ConnectedRealm { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("category")]
        public string Category { get; internal set; }

        [JsonProperty("locale")]
        public string Locale { get; internal set; }

        [JsonProperty("timezone")]
        public string Timezone { get; internal set; }

        [JsonProperty("type")]
        public TypeCommon Type { get; internal set; }

        [JsonProperty("is_tournament")]
        public bool IsTournament { get; internal set; }

        [JsonProperty("slug")]
        public string Slug { get; internal set; }
    }

    public class ConnectedRealmUrl
    {
        [JsonProperty("href")]
        public Uri Href { get; internal set; }
    }
}
