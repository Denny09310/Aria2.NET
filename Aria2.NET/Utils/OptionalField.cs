namespace Aria2.NET.Utils;

internal readonly struct OptionalField<T>(T? value)
{
    private readonly T? _value = value;

    public bool HasValue { get; } = !Equals(value, default(T));
    public T Value => HasValue ? _value! : throw new InvalidOperationException("No value present.");

    public static implicit operator OptionalField<T>(T? value) => new(value);
}
