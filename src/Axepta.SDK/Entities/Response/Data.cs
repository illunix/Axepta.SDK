namespace Axepta.SDK;

public sealed record Data
{
    [JsonPropertyName("transaction")]
    public Transaction? Transaction { get; init; }

    [JsonPropertyName("payment")]
    public PaymentResponse? Payment { get; init; }

    [JsonPropertyName("paymentLink")]
    public PaymentLink? PaymentLink { get; init; }

    [JsonPropertyName("action")]
    public Action? Action { get; init; }

    [JsonPropertyName("paymentRefundId")]
    public Guid? PaymentRefundId { get; init; }

    [JsonPropertyName("serviceId")]
    public Guid? ServiceId { get; init; }

    [JsonPropertyName("paymentId")]
    public Guid? PaymentId { get; init; }

    [JsonPropertyName("amount")]
    public int? Amount { get; init; }

    [JsonPropertyName("amountRefunded")]
    public int? AmountRefunded { get; init; }

    [JsonPropertyName("status")]
    public OrderStatus? Status { get; init; }

    [JsonPropertyName("validatorErrors")]
    public IReadOnlyList<ValidationError>? ValidationErrors { get; init; }
}