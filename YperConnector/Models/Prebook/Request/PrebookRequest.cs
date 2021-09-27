using Newtonsoft.Json;
using System;

namespace YperConnector.Models.Prebook.Request
{
    public class PrebookRequest
    {
        [JsonProperty("sender")]
        public Sender Sender;

        [JsonProperty("receiver")]
        public Receiver Receiver;

        [JsonProperty("delivery_address")]
        public DeliveryAddress DeliveryAddress;

        [JsonProperty("delivery_start")]
        public DateTime DeliveryStart;

        [JsonProperty("delivery_end")]
        public DateTime DeliveryEnd;

        [JsonProperty("order")]
        public Order Order;
    }
}
