using Newtonsoft.Json;
using System.Collections.Generic;

namespace Armory_CORE.Core.WorldOfWarcraft.Models.GameData
{
    public class RegionIndex
    {
        [JsonProperty("_links")]
        public Links Links { get; internal set; }

        public IEnumerable<Region> Regions { get; internal set; }
    }

    public class Region
    {
        [JsonProperty("_links")]
        public Links Links { get; internal set; }

        [JsonProperty("id")]
        public int Id { get; internal set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("tag")]
        public string Tag { get; internal set; }
    }
}
