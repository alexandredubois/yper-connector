using Newtonsoft.Json;

namespace YperConnector.Models.Prebook.Response
{
    public class Distance
    {
        [JsonProperty("base")]
        public double Base { get; set; }

        [JsonProperty("billed")]
        public double Billed { get; set; }
    }
}
