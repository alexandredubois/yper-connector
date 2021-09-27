using Newtonsoft.Json;

namespace YperConnector.Models.Prebook.Request
{
    public class DeliveryAddress
    {
        [JsonProperty("formatted_address")]
        public string FormattedAddress;

        [JsonProperty("additional_number")]
        public string AdditionalNumber;

        [JsonProperty("additional")]
        public string Additional;
    }
}
