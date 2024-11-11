using System.Text.Json.Serialization;

namespace Aria2.NET;

internal abstract class Aria2Response
{
    [JsonPropertyName("jsonrpc")]
    public string Version { get; set; } = "2.0";

    [JsonPropertyName("id")]
    public string? Id { get; set; }
}
