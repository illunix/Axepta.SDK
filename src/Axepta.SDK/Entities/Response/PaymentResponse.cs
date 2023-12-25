namespace Axepta.SDK;

public sealed record PaymentResponse
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("url")]
    public string? Url { get; init; }

    [JsonPropertyName("serviceId")]
    public Guid? ServiceId { get; init; }

    [JsonPropertyName("orderId")]
    public string? OrderId { get; init; }

    [JsonPropertyName("amount")]
    public string? Amount { get; init; }

    [JsonPropertyName("amountPaid")]
    public int? AmountPaid { get; init; }

    [JsonPropertyName("amountRefunded")]
    public int? AmountRefunded { get; init; }

    [JsonPropertyName("amountSubmittedRefund")]
    public int? AmountSubmittedRefund { get; init; }

    [JsonPropertyName("currency")]
    public string? Currency { get; init; }

    [JsonPropertyName("status")]
    public required OrderStatus Status { get; init; }

    [JsonPropertyName("isActive")]
    public bool? IsActive { get; init; }

    [JsonPropertyName("createdAt")]
    public int? CreatedAt { get; init; }

    [JsonPropertyName("modifiedAt")]
    public int? ModifiedAt { get; init; }

    [JsonPropertyName("isGenerated")]
    public bool? IsGenerated { get; init; }

    [JsonPropertyName("isUsed")]
    public bool? IsUsed { get; init; }

    [JsonPropertyName("isConfirmVisited")]
    public bool? IsConfirmVisited { get; init; }

    [JsonPropertyName("returnUrl")]
    public string? ReturnUrl { get; init; }

    [JsonPropertyName("failureReturnUrl")]
    public string? FailureReturnUrl { get; init; }

    [JsonPropertyName("successReturnUrl")]
    public string? SuccessReturnUrl { get; init; }

    [JsonPropertyName("customer")]
    public Customer? Customer { get; init; }
}