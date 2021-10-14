using Newtonsoft.Json;

namespace YperConnector.Models.Prebook.Request
{
    public class Extra
    {
        [JsonProperty("nb_items")]
        public int NbItems { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }
    }
}
