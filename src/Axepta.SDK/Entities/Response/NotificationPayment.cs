namespace Axepta.SDK;

public sealed record NotificationPayment
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("title")]
    public required string Title { get; init; }

    [JsonPropertyName("amount")]
    public required int Amount { get; init; }

    [JsonPropertyName("status")]
    public required string Status { get; init; }

    [JsonPropertyName("created")]
    public required int Created { get; init; }

    [JsonPropertyName("orderId")]
    public required string OrderId { get; init; }

    [JsonPropertyName("currency")]
    public required string Currency { get; init; }

    [JsonPropertyName("modified")]
    public required int Modified { get; init; }

    [JsonPropertyName("serviceId")]
    public required Guid ServiceId { get; init; }

    [JsonPropertyName("notificationUrl")]
    public required string NotificationUrl { get; init; }

    [JsonPropertyName("amountPaid")]
    public required int AmountPaid { get; init; }

    [JsonPropertyName("amountRefunded")]
    public required int AmountRefunded { get; init; }

    [JsonPropertyName("amountSubmittedRefund")]
    public required int AmountSubmittedRefund { get; init; }

    [JsonPropertyName("transactions")]
    public required IReadOnlyList<Transaction> Transactions { get; init; }

    [JsonPropertyName("notifyTransactionData")]
    public required NotificationTransactionData NotifyTransactionData { get; init; }
}