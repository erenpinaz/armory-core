using Newtonsoft.Json;

namespace Armory_CORE.Core.Models
{
    public class Token
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; internal set; }

        [JsonProperty("token_type")]
        public string TokenType { get; internal set; }

        [JsonProperty("expires_in")]
        public long Expiration { get; internal set; }

        [JsonProperty("scope")]
        public string Scope { get; internal set; }
    }
}
