namespace Axepta.SDK.Entities.Response;

public sealed record Action
{
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("method")]
    public required string Method { get; init; }

    [JsonPropertyName("contentType")]
    public required string ContentType { get; init; }

    [JsonPropertyName("contentBodyRaw")]
    public required string ContentBodyRaw { get; init; }
}