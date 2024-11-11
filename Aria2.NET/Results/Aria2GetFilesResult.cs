using System.Text.Json.Serialization;

namespace Aria2.NET.Results;

internal sealed class Aria2GetFilesResult : List<Aria2GetFilesItem>;

internal sealed class Aria2GetFilesItem
{
    [JsonPropertyName("completedLength")]
    public long CompletedLength { get; set; }

    [JsonPropertyName("index")]
    public int Index { get; set; }

    [JsonPropertyName("length")]
    public long Length { get; set; }

    [JsonPropertyName("path")]
    public string Path { get; set; } = default!;

    [JsonPropertyName("selected")]
    public bool Selected { get; set; }

    [JsonPropertyName("uris")]
    public string[] Uris { get; set; } = default!;
}