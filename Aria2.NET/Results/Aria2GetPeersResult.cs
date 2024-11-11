using System.Text.Json.Serialization;

namespace Aria2.NET.Results;

internal sealed class Aria2GetPeersResult : List<Aria2GetPeersItem>;

internal sealed class Aria2GetPeersItem
{
    [JsonPropertyName("amChocking")]
    public bool AmChoking { get; set; }

    [JsonPropertyName("downloadSpeed")]
    public double DownloadSpeed { get; set; }

    [JsonPropertyName("ip")]
    public string Ip { get; set; } = default!;

    [JsonPropertyName("peerChocking")]
    public bool PeerChocking { get; set; }

    [JsonPropertyName("peerId")]
    public string PeerId { get; set; } = default!;

    [JsonPropertyName("port")]
    public int Port { get; set; }

    [JsonPropertyName("seeder")]
    public bool Seeder { get; set; }

    [JsonPropertyName("uploadSpeed")]
    public double UploadSpeed { get; set; }
}