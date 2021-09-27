using Newtonsoft.Json;

namespace YperConnector.Models.Prebook.Response
{
    public class Result
    {
        [JsonProperty("distance")]
        public Distance Distance { get; set; }

        [JsonProperty("order")]
        public Order Order { get; set; }

        [JsonProperty("prebook_id")]
        public string PrebookId { get; set; }

        [JsonProperty("price")]
        public Price Price { get; set; }
    }
}
