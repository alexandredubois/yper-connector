
using Newtonsoft.Json;

namespace YperConnector.Models.PrebookValidation.Response
{
    public class PrebookValidationResponse
    {
        [JsonProperty("result")]
        public PrebookValidationResult Result { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }
    }
}
