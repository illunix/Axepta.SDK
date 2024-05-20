namespace Axepta.SDK.Entities.Response;

public sealed record NotificationPayment
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("amount")]
    public int Amount { get; set; }

    [JsonPropertyName("status")]
    public required OrderStatus Status { get; set; }

    [JsonPropertyName("created")]
    public int Created { get; set; }

    [JsonPropertyName("orderId")]
    public required string OrderId { get; set; }

    [JsonPropertyName("currency")]
    public required Currency Currency { get; set; }

    [JsonPropertyName("modified")]
    public int Modified { get; set; }

    [JsonPropertyName("serviceId")]
    public required string ServiceId { get; set; }

    [JsonPropertyName("notificationUrl")]
    public required string NotificationUrl { get; set; }

    [JsonPropertyName("amountPaid")]
    public int AmountPaid { get; set; }

    [JsonPropertyName("amountRefunded")]
    public int AmountRefunded { get; set; }

    [JsonPropertyName("amountSubmittedRefund")]
    public int AmountSubmittedRefund { get; set; }

    [JsonPropertyName("transactions")]
    public required List<NotificationTransaction> Transactions { get; set; }

    [JsonPropertyName("notifyTransactionData")]
    public required NotifyTransactionData NotifyTransactionData { get; set; }
}