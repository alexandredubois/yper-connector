using Newtonsoft.Json;

namespace YperConnector.Models.Prebook.Request
{
    public class Receiver
    {
        [JsonProperty("type")]
        public string Type;

        [JsonProperty("firstname")]
        public string Firstname;

        [JsonProperty("lastname")]
        public string Lastname;

        [JsonProperty("phone")]
        public string Phone;

        [JsonProperty("email")]
        public string Email;
    }
}
