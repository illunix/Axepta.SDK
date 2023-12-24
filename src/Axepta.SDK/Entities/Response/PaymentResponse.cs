namespace Axepta.SDK;

public sealed record PaymentResponse
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("serviceId")]
    public Guid? ServiceId { get; set; }

    [JsonPropertyName("orderId")]
    public string? OrderId { get; set; }

    [JsonPropertyName("amount")]
    public string? Amount { get; set; }

    [JsonPropertyName("amountPaid")]
    public int? AmountPaid { get; set; }

    [JsonPropertyName("amountRefunded")]
    public int? AmountRefunded { get; set; }

    [JsonPropertyName("amountSubmittedRefund")]
    public int? AmountSubmittedRefund { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("status")]
    public required OrderStatus Status { get; set; }

    [JsonPropertyName("isActive")]
    public bool? IsActive { get; set; }

    [JsonPropertyName("createdAt")]
    public int? CreatedAt { get; set; }

    [JsonPropertyName("modifiedAt")]
    public int? ModifiedAt { get; set; }

    [JsonPropertyName("isGenerated")]
    public bool? IsGenerated { get; set; }

    [JsonPropertyName("isUsed")]
    public bool? IsUsed { get; set; }

    [JsonPropertyName("isConfirmVisited")]
    public bool? IsConfirmVisited { get; set; }

    [JsonPropertyName("returnUrl")]
    public string? ReturnUrl { get; set; }

    [JsonPropertyName("failureReturnUrl")]
    public string? FailureReturnUrl { get; set; }

    [JsonPropertyName("successReturnUrl")]
    public string? SuccessReturnUrl { get; set; }

    [JsonPropertyName("customer")]
    public Customer? Customer { get; set; }
}