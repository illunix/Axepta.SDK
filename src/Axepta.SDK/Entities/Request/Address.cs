namespace Axepta.SDK.Entities.Request;

/// <summary>
/// Represents a postal address with street, postal code, and city details.
/// </summary>
public sealed record Address
{
    /// <summary>
    /// Gets the street name of the address.
    /// </summary>
    /// <value>
    /// The street name as a string.
    /// </value>
    [JsonPropertyName("street")]
    public required string Street { get; init; }

    /// <summary>
    /// Gets the postal code of the address.
    /// </summary>
    /// <value>
    /// The postal code as a string.
    /// </value>
    [JsonPropertyName("postalCode")]
    public required string PostalCode { get; init; }

    /// <summary>
    /// Gets the city name of the address.
    /// </summary>
    /// <value>
    /// The city name as a string.
    /// </value>
    [JsonPropertyName("city")]
    public required string City { get; init; }
}
