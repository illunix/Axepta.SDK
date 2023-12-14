namespace Axepta.SDK.Entities.Request;

/// <summary>
/// Represents billing information for a customer, providing details such as name, address, and contact information.
/// </summary>
public record Billing
{
    /// <summary>
    /// Gets or initializes the first name of the customer.
    /// </summary>
    [StringLength(100)]
    [RegularExpression(AllowedCharactersPatterns.ADDITIONAL_ALLOWED_CHARACTERS_PATTERN)]
    [JsonPropertyName("firstName")]
    public required string FirstName { get; init; }

    /// <summary>
    /// Gets or initializes the last name of the customer.
    /// </summary>
    [StringLength(100)]
    [RegularExpression(AllowedCharactersPatterns.ADDITIONAL_ALLOWED_CHARACTERS_PATTERN)]
    [JsonPropertyName("lastName")]
    public required string LastName { get; init; }

    /// <summary>
    /// Gets or initializes the company name of the customer. Can be null.
    /// </summary>
    [StringLength(200)]
    [RegularExpression(AllowedCharactersPatterns.DEFAULT_ALLOWED_CHARACTERS_PATTERN)]
    [JsonPropertyName("company")]
    public string? Company { get; init; }

    /// <summary>
    /// Gets or initializes the street address of the customer. Can be null.
    /// </summary>
    [StringLength(200)]
    [RegularExpression(AllowedCharactersPatterns.DEFAULT_ALLOWED_CHARACTERS_PATTERN)]
    [JsonPropertyName("street")]
    public string? Street { get; init; }

    /// <summary>
    /// Gets or initializes the city of the customer. Can be null.
    /// </summary>
    [StringLength(100)]
    [RegularExpression(AllowedCharactersPatterns.DEFAULT_ALLOWED_CHARACTERS_PATTERN)]
    [JsonPropertyName("city")]
    public string? City { get; init; }

    /// <summary>
    /// Gets or initializes the region or state of the customer. Can be null.
    /// </summary>
    [StringLength(100)]
    [RegularExpression(AllowedCharactersPatterns.DEFAULT_ALLOWED_CHARACTERS_PATTERN)]
    [JsonPropertyName("region")]
    public string? Region { get; init; }

    /// <summary>
    /// Gets or initializes the postal code of the customer. Can be null.
    /// </summary>
    [StringLength(30)]
    [JsonPropertyName("postalCode")]
    public string? PostalCode { get; init; }

    /// <summary>
    /// Gets or initializes the country code (ISO 3166-1 alpha-2) of the customer. Can be null.
    /// </summary>
    [StringLength(20)]
    [JsonPropertyName("countryCodeAlpha2")]
    public string? CountryCodeAlpha2 { get; init; }
}
