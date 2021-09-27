using Newtonsoft.Json;

namespace YperConnector.Models.Prebook.Request
{
    public class Sender
    {
        [JsonProperty("type")]
        public string Type;

        [JsonProperty("id")]
        public string Id;
    }
}
