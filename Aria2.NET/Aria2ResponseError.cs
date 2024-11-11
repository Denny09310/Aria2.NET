using System.Text.Json.Serialization;

namespace Aria2.NET;

internal sealed class Aria2ResponseError : Aria2Response
{
    [JsonPropertyName("error")]
    public Aria2Error Error { get; set; } = default!;

    internal sealed class Aria2Error
    {
        [JsonPropertyName("message")]
        public string Message { get; set; } = default!;

        [JsonPropertyName("code")]
        public int Code { get; set; }
    }
}