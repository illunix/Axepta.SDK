namespace Axepta.SDK;

public sealed record PaymentLink
{
    [JsonPropertyName("paymentId")]
    public required string PaymentId { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }
}