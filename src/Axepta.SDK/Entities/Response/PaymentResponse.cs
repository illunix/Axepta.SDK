namespace Axepta.SDK.Entities.Response;

public sealed record PaymentResponse
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("status")]
    public required string Status { get; init; }
}