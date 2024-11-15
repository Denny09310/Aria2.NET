﻿using System.Text.Json.Serialization;

namespace Aria2.NET.Results;

internal sealed class Aria2GetGlobalStatResult
{
    [JsonPropertyName("downloadSpeed")]
    public double DownloadSpeed { get; set; }

    [JsonPropertyName("numActive")]
    public int NumActive { get; set; }

    [JsonPropertyName("numStopped")]
    public int NumStopped { get; set; }

    [JsonPropertyName("numStoppedTotal")]
    public int NumStoppedTotal { get; set; }

    [JsonPropertyName("numWaiting")]
    public int NumWaiting { get; set; }

    [JsonPropertyName("uploadSpeed")]
    public double UploadSpeed { get; set; }
}