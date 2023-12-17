namespace Axepta.SDK;

public sealed record Transaction
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("type")]
    public required string Type { get; init; }

    [JsonPropertyName("status")]
    public required OrderStatus Status { get; init; }

    [JsonPropertyName("source")]
    public required OrderSource Source { get; init; }

    [JsonPropertyName("createdAt")]
    public required int CreatedAt { get; init; }

    [JsonPropertyName("modifiedAt")]
    public required int ModifiedAt { get; init; }

    [JsonPropertyName("notificationUrl")]
    public required string NotificationUrl { get; init; }

    [JsonPropertyName("serviceId")]
    public required Guid ServiceId { get; init; }

    [JsonPropertyName("amount")]
    public required int Amount { get; init; }

    [JsonPropertyName("currency")]
    public required string Currency { get; init; }

    [JsonPropertyName("orderId")]
    public required string OrderId { get; init; }

    [JsonPropertyName("paymentMethod")]
    public required PaymentMethod PaymentMethod { get; init; }

    [JsonPropertyName("paymentMethodChannel")]
    public required PaymentMethodChannel PaymentMethodChannel { get; init; }

    [JsonPropertyName("payment")]
    public required PaymentResponse Payment { get; init; }
}