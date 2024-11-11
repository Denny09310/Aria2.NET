using System.Text.Json.Serialization;

namespace Aria2.NET;

internal sealed class Aria2ResponseSuccess<T> : Aria2Response
{
    [JsonPropertyName("result")]
    public T Result { get; set; } = default!;
}
