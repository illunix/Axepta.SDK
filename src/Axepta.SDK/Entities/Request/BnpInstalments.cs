namespace Axepta.SDK.Entities.Request;

/// <summary>
/// Represents the installments information for BNP, including address, credit types, and products.
/// </summary>
public sealed record BnpInstalments
{
    /// <summary>
    /// Gets the address associated with the BNP installment.
    /// </summary>
    /// <value>
    /// The address as a string.
    /// </value>
    [JsonPropertyName("address")]
    public required string Address { get; init; }

    /// <summary>
    /// Gets the list of credit types associated with the BNP installment.
    /// </summary>
    /// <value>
    /// A read-only list of integers representing credit types.
    /// </value>
    [JsonPropertyName("creditTypes")]
    public required IReadOnlyList<int> CreditTypes { get; init; }

    /// <summary>
    /// Gets the list of products associated with the BNP installment.
    /// </summary>
    /// <value>
    /// A read-only list of <see cref="Product"/> objects.
    /// </value>
    [JsonPropertyName("products")]
    public required IReadOnlyList<Product> Products { get; init; }
}
