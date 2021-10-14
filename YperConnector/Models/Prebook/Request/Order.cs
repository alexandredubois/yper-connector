using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace YperConnector.Models.Prebook.Request
{
    public class Order
    {
        [JsonProperty("order_id")]
        public string OrderId;

        [JsonProperty("transport_type")]
        [Newtonsoft.Json.JsonConverter(typeof(JsonStringEnumConverter))]
        public TransportType TransportType { get; set; }
    }
}
