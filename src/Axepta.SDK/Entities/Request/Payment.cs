namespace Axepta.SDK.Entities.Request;

/// <summary>
/// Represents payment information, including details such as payment type, service ID, amount, and customer information.
/// </summary>
public sealed record Payment
{
    /// <summary>
    /// Gets or initializes the type of payment.
    /// </summary>
    [JsonPropertyName("type")]
    public required PaymentType Type { get; init; }

    /// <summary>
    /// Gets or initializes the service ID associated with the payment.
    /// </summary>
    [JsonPropertyName("serviceId")]
    public required string ServiceId { get; init; }

    /// <summary>
    /// Gets or initializes the amount of the payment.
    /// </summary>
    [JsonPropertyName("amount")]
    public required int Amount { get; init; }

    /// <summary>
    /// Gets or initializes the currency code for the payment amount.
    /// </summary>
    [StringLength(3)]
    [JsonPropertyName("currency")]
    public required string Currency { get; init; }

    /// <summary>
    /// Gets or initializes the unique identifier for the payment order.
    /// </summary>
    [StringLength(100)]
    [RegularExpression(AllowedCharactersPatterns.ADDITIONAL_ALLOWED_CHARACTERS_PATTERN)]
    [JsonPropertyName("orderId")]
    public required string OrderId { get; init; }

    /// <summary>
    /// Gets or initializes the payment method used for the transaction.
    /// </summary>
    [JsonPropertyName("paymentMethod")]
    public required PaymentMethod PaymentMethod { get; init; }

    /// <summary>
    /// Gets or initializes the payment method channel for the transaction.
    /// </summary>
    [JsonPropertyName("paymentMethodChannel")]
    public required string PaymentMethodChannel { get; init; }

    /// <summary>
    /// Gets or initializes the URL to redirect to after a successful payment.
    /// </summary>
    [StringLength(300)]
    [Url]
    [JsonPropertyName("successReturnUrl")]
    public required string SuccessReturnUrl { get; init; }

    /// <summary>
    /// Gets or initializes the URL to redirect to after a failed payment.
    /// </summary>
    [StringLength(300)]
    [Url]
    [JsonPropertyName("failureReturnUrl")]
    public required string FailureReturnUrl { get; init; }

    /// <summary>
    /// Gets or initializes the general return URL for the payment.
    /// </summary>
    [StringLength(300)]
    [Url]
    [JsonPropertyName("returnUrl")]
    public required string ReturnUrl { get; init; }

    /// <summary>
    /// Gets or initializes information about the customer making the payment.
    /// </summary>
    [JsonPropertyName("customer")]
    public required Customer Customer { get; init; }

    /// <summary>
    /// Gets or initializes the title associated with the payment. Can be null.
    /// </summary>
    [StringLength(255)]
    [RegularExpression(AllowedCharactersPatterns.ADDITIONAL_ALLOWED_CHARACTERS_PATTERN)]
    [JsonPropertyName("title")]
    public string? Title { get; init; }

    /// <summary>
    /// Gets or initializes billing information associated with the payment. Can be null.
    /// </summary>
    [JsonPropertyName("billing")]
    public Billing? Billing { get; init; }

    /// <summary>
    /// Gets or initializes shipping information associated with the payment. Can be null.
    /// </summary>
    [JsonPropertyName("shipping")]
    public Shipping? Shipping { get; init; }

    /// <summary>
    /// Gets or initializes credit card information associated with the payment. Can be null.
    /// </summary>
    [RequiredIf(
        nameof(PaymentMethod),
        PaymentMethod.Card
    )]
    [JsonPropertyName("card")]
    public Card? Card { get; init; }

    /// <summary>
    /// Gets or initializes additional data associated with the payment. Can be null.
    /// </summary>
    [JsonPropertyName("additionalData")]
    public AdditionalData? AdditionalData { get; init; }

    /// <summary>
    /// Gets or initializes the timestamp representing the expiration date and time of the transaction.
    /// If not provided, the transaction is considered valid indefinitely. Failure to complete the payment
    /// by the specified timestamp will result in the cancellation of the transaction.
    /// </summary>
    [JsonPropertyName("activeTo")]
    public DateTime? ActiveTo { get; init; }
}
