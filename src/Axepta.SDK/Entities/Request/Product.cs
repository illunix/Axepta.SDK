namespace Axepta.SDK.Entities.Request;

/// <summary>
/// Represents a product with details like name, price, quantity, and code.
/// </summary>
public sealed record Product
{
    private int _amount;

    /// <summary>
    /// Gets the name of the product.
    /// </summary>
    /// <value>
    /// The name of the product as a string.
    /// </value>
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    /// <summary>
    /// Gets or sets the price of the product. 
    /// The set method converts the input price from dollars to cents.
    /// </summary>
    /// <value>
    /// The price of the product in cents as an integer.
    /// </value>
    [JsonPropertyName("price")]
    public required int Price
    {
        get => _amount;
        set => _amount = value * 100; 
    }

    /// <summary>
    /// Gets the quantity of the product.
    /// </summary>
    /// <value>
    /// The quantity of the product as an integer.
    /// </value>
    [JsonPropertyName("quantity")]
    public required int Quantity { get; init; }

    /// <summary>
    /// Gets the code of the product.
    /// </summary>
    /// <value>
    /// The code of the product as an integer.
    /// </value>
    [JsonPropertyName("code")]
    public required int Code { get; init; }
}
