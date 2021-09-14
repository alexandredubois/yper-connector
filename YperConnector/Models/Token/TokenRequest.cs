using Newtonsoft.Json;

namespace YperConnector.Models.Token
{
    public class TokenRequest
    {
        [JsonProperty(PropertyName = "client_id")]
        public string ClientId { get; set; }

        [JsonProperty(PropertyName = "client_secret")]
        public string ClientSecret { get; set; }

        [JsonProperty(PropertyName = "pro_id")]
        public string ProId { get; set; }

        [JsonProperty(PropertyName = "pro_secret_token")]
        public string ProSecret { get; set; }

        [JsonProperty(PropertyName = "grant_type")]
        public string GrantType { get; set; }
    }
}
