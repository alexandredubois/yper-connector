using Newtonsoft.Json;

namespace YperConnector.Models.Prebook.Response
{
    public class PrebookResponse
    {
        [JsonProperty("result")]
        public Result Result { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }
    }
}
