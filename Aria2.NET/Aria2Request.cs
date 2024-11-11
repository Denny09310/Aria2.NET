using System.Text.Json.Serialization;

namespace Aria2.NET;

internal sealed class Aria2Request
{
    [JsonPropertyName("jsonrpc")]
    public string Version { get; set; } = "2.0";

    [JsonPropertyName("id")]
    public string? Id { get; set; } = Guid.NewGuid().ToString();

    [JsonPropertyName("method")]
    public required string Method { get; set; }

    [JsonPropertyName("params")]
    public IList<object> Params { get; set; } = [];
}
