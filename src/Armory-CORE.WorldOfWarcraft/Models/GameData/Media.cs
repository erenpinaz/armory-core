using Newtonsoft.Json;
using System.Collections.Generic;

namespace Armory_CORE.Core.WorldOfWarcraft.Models
{
    public class Media
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("assets")]
        public IEnumerable<Asset> Assets { get; set; }
    }

    public class Asset
    {
        [JsonProperty("key")]
        public string Key { get; internal set; }

        [JsonProperty("value")]
        public string Value { get; internal set; }

        [JsonProperty("file_data_id")]
        public int FileDataId { get; set; }
    }
}
