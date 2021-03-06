using Newtonsoft.Json;
using System.Collections.Generic;

namespace Armory_CORE.Core.WorldOfWarcraft.Models.Profile
{
    public class CharacterMediaSummary
    {
        [JsonProperty("_links")]
        public Links Links { get; internal set; }

        [JsonProperty("character")]
        public Character Character { get; internal set; }

        [JsonProperty("assets")]
        public IEnumerable<Asset> Assets { get; set; }
    }
}
