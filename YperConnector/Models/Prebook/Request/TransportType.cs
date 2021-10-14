using System.Text.Json.Serialization;

namespace YperConnector.Models.Prebook.Request
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TransportType
    {
        car,
        @break,
        moto,
        foot,
        bike
    }
}
