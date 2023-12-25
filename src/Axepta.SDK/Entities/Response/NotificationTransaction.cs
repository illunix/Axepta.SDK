namespace Axepta.SDK;

public sealed record NotificationTransaction
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("type")]
    public required string Type { get; init; }

    [JsonPropertyName("status")]
    public required string Status { get; init; }

    [JsonPropertyName("source")]
    public required string Source { get; init; }

    [JsonPropertyName("created")]
    public required int Created { get; init; }

    [JsonPropertyName("modified")]
    public required int Modified { get; init; }

    [JsonPropertyName("notificationUrl")]
    public required string NotificationUrl { get; init; }

    [JsonPropertyName("serviceId")]
    public required Guid ServiceId { get; init; }

    [JsonPropertyName("amount")]
    public required int Amount { get; init; }

    [JsonPropertyName("currency")]
    public required string Currency { get; init; }

    [JsonPropertyName("title")]
    public required string Title { get; init; }

    [JsonPropertyName("orderId")]
    public required string OrderId { get; init; }

    [JsonPropertyName("paymentMethod")]
    public required PaymentMethod PaymentMethod { get; init; }

    [JsonPropertyName("paymentMethodCode")]
    public required string PaymentMethodCode { get; init; }
}