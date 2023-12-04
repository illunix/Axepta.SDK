namespace Axepta.SDK.Entities;

/// <summary>
/// Represents a customer with essential information.
/// </summary>
public sealed record Customer
{
    /// <summary>
    /// Gets or initializes the unique identifier for the customer.
    /// </summary>
    [StringLength(100)]
    [JsonPropertyName("cid")]
    public string? Id { get; init; }

    /// <summary>
    /// Gets or initializes the first name of the customer.
    /// </summary>
    [StringLength(100)]
    [JsonPropertyName("firstName")]
    public required string FirstName { get; init; }

    /// <summary>
    /// Gets or initializes the last name of the customer.
    /// </summary>
    [StringLength(100)]
    [JsonPropertyName("lastName")]
    public required string LastName { get; init; }

    /// <summary>
    /// Gets or initializes the email address of the customer.
    /// </summary>
    [EmailAddress]
    [StringLength(200)]
    [JsonPropertyName("email")]
    public required string Email { get; init; }

    /// <summary>
    /// Gets or initializes the phone number of the customer. Only the characters -+0-9 and space are allowed.
    /// </summary>
    [StringLength(20)]
    [JsonPropertyName("phone")]
    [RegularExpression(@"^[+\- 0-9]*$")]
    public string? Phone { get; init; }
}
