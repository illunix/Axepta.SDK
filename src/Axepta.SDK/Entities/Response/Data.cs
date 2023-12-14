namespace Axepta.SDK.Entities.Response;

public sealed record Data
{
    [JsonPropertyName("transaction")]
    public required Transaction Transaction { get; init; }

    [JsonPropertyName("action")]
    public required Action Action { get; init; }
}