using System.Text.Json.Serialization;

namespace Aria2.NET.Results;

internal sealed class Aria2GidResult
{
    [JsonPropertyName("gid")]
    public string Gid { get; set; } = default!;
}