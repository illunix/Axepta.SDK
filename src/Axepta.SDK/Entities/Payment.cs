namespace Axepta.SDK.Entities;

public sealed record Payment
{
    /// <summary>
    /// Gets or initializes the store ID as UUID v4.
    /// </summary>
    [StringLength(36)]
    [JsonPropertyName("serviceId")]
    public required string ServiceId { get; init; }

    /// <summary>
    /// Gets or initializes the client ID.
    /// </summary>
    [StringLength(20)]
    [JsonPropertyName("merchantId")]
    public required string MerchantId { get; init; }

    /// <summary>
    /// Gets or initializes the amount of the transaction in the smallest unit of currency (e.g., cents).
    /// </summary>
    [JsonPropertyName("amount")]
    public required int Amount { get; init; }

    /// <summary>
    /// Gets or initializes the amount of the transaction in the smallest unit of currency (e.g., cents).
    /// </summary>
    [StringLength(3)]
    [JsonPropertyName("currency")]
    public required string Currency { get; init; }

    [StringLength(100)]
    [JsonPropertyName("orderId")]
    public required string OrderId { get; init; }

    [JsonPropertyName("customer")]
    public required Customer Customer { get; init; }

    [JsonPropertyName("signature")]
    public required string Signature { get; init; }

    [StringLength(100)]
    [JsonPropertyName("title")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; init; }

    [StringLength(300)]
    [JsonPropertyName("successReturnUrl")]
    public string? SuccessReturnUrl { get; init; }

    [StringLength(300)]
    [JsonPropertyName("failureReturnUrl")]
    public string? FailureReturnUrl { get; init; }

    [StringLength(300)]
    [JsonPropertyName("returnUrl")]
    public string? ReturnUrl { get; init; }

    [JsonPropertyName("visibleMethod")]
    public IEnumerable<string>? Methods { get; init; }

    [JsonPropertyName("cartData")]
    public string? CartData { get; init; }

    [JsonPropertyName("creditType")]
    public IEnumerable<string>? CreditType { get; init; }

    [JsonPropertyName("activeTo")]
    public string? ActiveTo { get; init; }

    [JsonPropertyName("paywall")]
    public PayWall? Paywall { get; init; }
}