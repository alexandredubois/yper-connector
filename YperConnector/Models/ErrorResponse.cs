using Newtonsoft.Json;

namespace YperConnector.Models
{
    public class ErrorResponse
    {
        [JsonProperty(PropertyName = "error_code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "error_message")]
        public string Message { get; set; }
    }
}
