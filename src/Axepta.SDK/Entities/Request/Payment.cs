namespace Axepta.SDK;

/// <summary>
/// Represents a payment transaction, encapsulating details such as payment type, service ID,
/// amount, currency, and customer information. This record is designed to handle various aspects
/// of a payment process including the transaction details, payment methods, and redirection URLs
/// for successful or failed payments.
/// </summary>
public sealed record Payment
{
    private int _amount;

    /// <summary>
    /// Gets or sets the type of payment. This property specifies the category or method of the payment.
    /// </summary>
    [JsonPropertyName("type")]
    public required PaymentType Type { get; init; }

    /// <summary>
    /// Gets or sets the service ID associated with the payment. This is a unique identifier for the service involved in the payment.
    /// </summary>
    [JsonPropertyName("serviceId")]
    public string? ServiceId { get; private set; }

    /// <summary>
    /// Gets or sets the payment amount. The setter converts the input amount from a major currency unit (e.g., dollars) to a minor unit (e.g., cents).
    /// </summary>
    [JsonPropertyName("amount")]
    public required int Amount
    {
        get => _amount;
        set => _amount = value * 100;
    }

    /// <summary>
    /// Gets or sets the currency code for the payment, following the ISO 4217 standard.
    /// </summary>
    [StringLength(3)]
    [JsonPropertyName("currency")]
    public required Currency Currency { get; init; }

    /// <summary>
    /// Gets or sets the unique identifier for the payment order, which can be used for tracking and referencing the transaction.
    /// </summary>
    [StringLength(100)]
    [RegularExpression(AllowedCharactersPatterns.ADDITIONAL_ALLOWED_CHARACTERS_PATTERN)]
    [JsonPropertyName("orderId")]
    public required string OrderId { get; init; }

    /// <summary>
    /// Gets or sets the payment method used for the transaction. It defines how the payment is processed.
    /// </summary>
    [JsonPropertyName("paymentMethod")]
    public required PaymentMethod PaymentMethod { get; init; }

    /// <summary>
    /// Gets or sets the channel through which the payment method is applied, providing additional context for the payment process.
    /// </summary>
    [JsonPropertyName("paymentMethodChannel")]
    public required PaymentMethodChannel PaymentMethodChannel { get; init; }

    /// <summary>
    /// Gets or sets the URL to which the user is redirected after a successful payment. This URL is used for post-transaction navigation.
    /// </summary>
    [StringLength(300)]
    [Url]
    [JsonPropertyName("successReturnUrl")]
    public required string SuccessReturnUrl { get; init; }

    /// <summary>
    /// Gets or sets the URL to which the user is redirected after a failed payment. This provides a means to handle unsuccessful transactions.
    /// </summary>
    [StringLength(300)]
    [Url]
    [JsonPropertyName("failureReturnUrl")]
    public required string FailureReturnUrl { get; init; }

    /// <summary>
    /// Gets or sets a general return URL for the payment, used for redirecting the user after the transaction is processed, regardless of the outcome.
    /// </summary>
    [StringLength(300)]
    [Url]
    [JsonPropertyName("returnUrl")]
    public required string ReturnUrl { get; init; }

    /// <summary>
    /// Gets or sets the customer's information, essential for processing the payment and for record-keeping purposes.
    /// </summary>
    [JsonPropertyName("customer")]
    public required Customer Customer { get; init; }

    /// <summary>
    /// Gets or sets the IP address of the client initiating the payment. This can be used for security and auditing purposes.
    /// </summary>
    [JsonPropertyName("clientIp")]
    public required string ClientIp { get; init; }

    /// <summary>
    /// Gets or sets the title associated with the payment. This can be a description or label for the payment, and can be null.
    /// </summary>
    [StringLength(255)]
    [RegularExpression(AllowedCharactersPatterns.ADDITIONAL_ALLOWED_CHARACTERS_PATTERN)]
    [JsonPropertyName("title")]
    public string? Title { get; init; }

    /// <summary>
    /// Gets or sets the billing information for the payment, including details like billing address. This property is optional.
    /// </summary>
    [JsonPropertyName("billing")]
    public Billing? Billing { get; init; }

    /// <summary>
    /// Gets or sets the shipping information for the payment, applicable when the payment involves physical goods. This property is optional.
    /// </summary>
    [JsonPropertyName("shipping")]
    public Shipping? Shipping { get; init; }

    /// <summary>
    /// Gets or sets the credit card information for the payment, required if the payment method is a card. This property is conditional based on the payment method.
    /// </summary>
    [RequiredIf(nameof(PaymentMethod), PaymentMethod.Card)]
    [JsonPropertyName("card")]
    public Card? Card { get; init; }

    /// <summary>
    /// Gets or sets the BNP instalments information for the payment, providing details for installment-based payments. This property is optional.
    /// </summary>
    [JsonPropertyName("bnpInstalments")]
    public BnpInstalments? BnpInstalments { get; init; }

    /// <summary>
    /// Gets or sets additional data associated with the payment, which can include any extra information relevant to the payment. This property is optional.
    /// </summary>
    [JsonPropertyName("additionalData")]
    public AdditionalData? AdditionalData { get; init; }

    /// <summary>
    /// Gets or sets the expiration date and time of the transaction. If not specified, the transaction remains valid indefinitely.
    /// Transactions not completed by this timestamp will be automatically cancelled.
    /// </summary>
    [JsonPropertyName("activeTo")]
    public DateTime? ActiveTo { get; init; }

    internal void SetServiceId(string serviceId)
        => ServiceId = serviceId;
}
