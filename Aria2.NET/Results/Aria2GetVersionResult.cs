using System.Text.Json.Serialization;

namespace Aria2.NET.Results;

internal sealed class Aria2GetVersionResult
{
    [JsonPropertyName("features")]
    public string[] Features { get; set; } = default!;

    [JsonPropertyName("version")]
    public string Version { get; set; } = default!;
}