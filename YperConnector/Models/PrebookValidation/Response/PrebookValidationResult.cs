using Newtonsoft.Json;

namespace YperConnector.Models.PrebookValidation.Response
{
    public class PrebookValidationResult
    {
        [JsonProperty("mission_id")]
        public string MissionId { get; set; }
    }
}
