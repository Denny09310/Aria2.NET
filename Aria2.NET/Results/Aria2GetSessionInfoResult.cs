using System.Text.Json.Serialization;

namespace Aria2.NET.Results;

internal sealed class Aria2GetSessionInfoResult
{
    [JsonPropertyName("sessionId")]
    public string SessionId { get; set; } = default!;
}