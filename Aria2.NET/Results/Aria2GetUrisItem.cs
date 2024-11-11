using System.Text.Json.Serialization;

namespace Aria2.NET.Results;

internal sealed class Aria2GetUrisResult : List<Aria2GetUrisItem>;

internal sealed class Aria2GetUrisItem
{
    [JsonPropertyName("status")]
    public string Status { get; set; } = default!;

    [JsonPropertyName("uri")]
    public string Uri { get; set; } = default!;
}