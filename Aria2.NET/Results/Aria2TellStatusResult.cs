using System.Text.Json.Serialization;
using Aria2.NET.Utils;

namespace Aria2.NET.Results;

internal sealed class Aria2TellStatusResult
{
    [JsonPropertyName("belongsTo")]
    public OptionalField<string> BelongsTo { get; set; }

    [JsonPropertyName("bittorrent")]
    public OptionalField<Aria2BitTorrent> Bittorrent { get; set; }

    [JsonPropertyName("completedLength")]
    public OptionalField<long> CompletedLength { get; set; }

    [JsonPropertyName("connections")]
    public OptionalField<int> Connections { get; set; }

    [JsonPropertyName("dir")]
    public OptionalField<string> Dir { get; set; }

    [JsonPropertyName("downloadSpeed")]
    public OptionalField<double> DownloadSpeed { get; set; }

    [JsonPropertyName("errorCode")]
    public OptionalField<string> ErrorCode { get; set; }

    [JsonPropertyName("errorMessage")]
    public OptionalField<string> ErrorMessage { get; set; }

    [JsonPropertyName("files")]
    public OptionalField<string[]> Files { get; set; }

    [JsonPropertyName("followedBy")]
    public OptionalField<string[]> FollowedBy { get; set; }

    [JsonPropertyName("following")]
    public OptionalField<string> Following { get; set; }

    [JsonPropertyName("gid")]
    public OptionalField<string> Gid { get; set; } = default!;

    [JsonPropertyName("infoHash")]
    public OptionalField<string> InfoHash { get; set; }

    [JsonPropertyName("numPieces")]
    public OptionalField<int> NumPieces { get; set; }

    [JsonPropertyName("numSeeders")]
    public OptionalField<int> NumSeeders { get; set; }

    [JsonPropertyName("pieceLength")]
    public OptionalField<long> PieceLength { get; set; }

    [JsonPropertyName("seeder")]
    public OptionalField<bool> Seeder { get; set; }

    [JsonPropertyName("status")]
    public OptionalField<string> Status { get; set; }

    [JsonPropertyName("totalLength")]
    public OptionalField<long> TotalLength { get; set; }

    [JsonPropertyName("uploadLength")]
    public OptionalField<long> UploadLength { get; set; }

    [JsonPropertyName("uploadSpeed")]
    public OptionalField<double> UploadSpeed { get; set; }

    [JsonPropertyName("verifiedLength")]
    public OptionalField<long> VerifiedLength { get; set; }

    [JsonPropertyName("verifyIntegrityPending")]
    public OptionalField<bool> VerifyIntegrityPending { get; set; }

    public sealed class Aria2BitTorrent
    {
        [JsonPropertyName("announceList")]
        public string[] AnnounceList { get; set; } = default!;

        [JsonPropertyName("comment")]
        public string Comment { get; set; } = default!;

        [JsonPropertyName("creationDate")]
        public DateTime CreationDate { get; set; }

        [JsonPropertyName("info")]
        public Aria2Info Info { get; set; } = default!;

        [JsonPropertyName("mode")]
        public string Mode { get; set; } = default!;

        public sealed class Aria2Info
        {
            [JsonPropertyName("name")]
            public string Name { get; set; } = default!;
        }
    }
}