﻿using Newtonsoft.Json;

namespace YperConnector.Models.Prebook.Request
{
    public class Order
    {
        [JsonProperty("order_id")]
        public string OrderId;
    }
}
