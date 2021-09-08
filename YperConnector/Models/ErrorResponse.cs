﻿using Newtonsoft.Json;

namespace YperConnector.Models
{
    public class ErrorResponse
    {
        //TODO adapter au format de Yper
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        [JsonProperty(PropertyName = "error_description")]
        public string ErrorDescription { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "data")]
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonProperty(PropertyName = "deliveries")]
        public string[] Deliveries { get; set; }
    }
}
