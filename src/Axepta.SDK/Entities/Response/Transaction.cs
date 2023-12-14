namespace Axepta.SDK.Entities.Response;

public sealed record Transaction
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("type")]
    public required string Type { get; init; }

    [JsonPropertyName("status")]
    public required string Status { get; init; }

    [JsonPropertyName("source")]
    public required string Source { get; init; }

    [JsonPropertyName("createdAt")]
    public required int CreatedAt { get; init; }

    [JsonPropertyName("modifiedAt")]
    public required int ModifiedAt { get; init; }

    [JsonPropertyName("notificationUrl")]
    public required string NotificationUrl { get; init; }

    [JsonPropertyName("serviceId")]
    public required string ServiceId { get; init; }

    [JsonPropertyName("amount")]
    public required int Amount { get; init; }

    [JsonPropertyName("currency")]
    public required string Currency { get; init; }

    [JsonPropertyName("orderId")]
    public required string OrderId { get; init; }

    [JsonPropertyName("paymentMethod")]
    public required string PaymentMethod { get; init; }

    [JsonPropertyName("paymentMethodChannel")]
    public required string PaymentMethodChannel { get; init; }

    [JsonPropertyName("payment")]
    public required PaymentResponse Payment { get; init; }
}