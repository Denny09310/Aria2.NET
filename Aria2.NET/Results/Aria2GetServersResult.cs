using System.Text.Json.Serialization;

namespace Aria2.NET.Results;

internal sealed class Aria2GetServersResult : List<Aria2GetServersItem>;

internal sealed class Aria2GetServersItem
{
    [JsonPropertyName("downloadSpeed")]
    public double DownloadSpeed { get; set; }

    [JsonPropertyName("originalUri")]
    public string OriginalUri { get; set; } = default!;

    [JsonPropertyName("uri")]
    public string Uri { get; set; } = default!;
}