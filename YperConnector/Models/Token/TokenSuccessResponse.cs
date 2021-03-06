using Newtonsoft.Json;

namespace YperConnector.Models.Token
{
    public class TokenSuccessResponse
    {
        [JsonProperty("result")]
        public TokenResult Result { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }
    }
}
