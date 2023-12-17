namespace Axepta.SDK;

/// <summary>
/// Represents credit card information, including the cardholder's name, card number, expiration date, and CVV.
/// </summary>
public sealed record Card
{
    /// <summary>
    /// Gets or initializes the first name of the cardholder.
    /// </summary>
    [StringLength(100)]
    [RegularExpression(AllowedCharactersPatterns.ADDITIONAL_ALLOWED_CHARACTERS_PATTERN)]
    [JsonPropertyName("firstName")]
    public required string FirstName { get; init; }

    /// <summary>
    /// Gets or initializes the last name of the cardholder.
    /// </summary>
    [StringLength(100)]
    [RegularExpression(AllowedCharactersPatterns.ADDITIONAL_ALLOWED_CHARACTERS_PATTERN)]
    [JsonPropertyName("lastName")]
    public required string LastName { get; init; }

    /// <summary>
    /// Gets or initializes the card number.
    /// </summary>
    [StringLength(16)]
    [JsonPropertyName("number")]
    public required string Number { get; init; }

    /// <summary>
    /// Gets or initializes the expiration month of the card.
    /// </summary>
    [StringLength(2)]
    [JsonPropertyName("month")]
    public required string Month { get; init; }

    /// <summary>
    /// Gets or initializes the expiration year of the card.
    /// </summary>
    [StringLength(4)]
    [JsonPropertyName("year")]
    public required string Year { get; init; }

    /// <summary>
    /// Gets or initializes the CVV (Card Verification Value) of the card.
    /// </summary>
    [StringLength(4)]
    [JsonPropertyName("cvv")]
    public required string Cvv { get; init; }
}
