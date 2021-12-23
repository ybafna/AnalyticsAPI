using System.Text.Json.Serialization;

namespace AnalyticsAPI.Models{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EventType
    {
        Click,
        Copy,
        Print
    }
}