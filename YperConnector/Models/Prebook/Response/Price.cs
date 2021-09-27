using Newtonsoft.Json;

namespace YperConnector.Models.Prebook.Response
{
    public class Price
    {
        [JsonProperty("base")]
        public double Base { get; set; }

        [JsonProperty("total_ht")]
        public double TotalHt { get; set; }

        [JsonProperty("total_ttc")]
        public double TotalTtc { get; set; }

        [JsonProperty("tva")]
        public double Tva { get; set; }
    }
}
