using Newtonsoft.Json;

namespace YperConnector.Models.Prebook.Response
{
    public class Order
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
