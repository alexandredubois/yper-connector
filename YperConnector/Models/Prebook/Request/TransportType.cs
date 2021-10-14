using Newtonsoft.Json.Converters;

namespace YperConnector.Models.Prebook.Request
{
    [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
    public enum TransportType
    {
        car,
        @break,
        moto,
        foot,
        bike
    }
}
