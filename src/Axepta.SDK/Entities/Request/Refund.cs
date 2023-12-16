namespace Axepta.SDK.Entities.Request;

/// <summary>
/// Represents a refund transaction, including information such as the type of transaction, 
/// service ID, and the refund amount. This class is designed to handle the specifics of processing a refund.
/// </summary>
public sealed class Refund
{
    private readonly int _amount;

    /// <summary>
    /// Gets the type of transaction, which is set to "refund" by default.
    /// This property indicates the nature of the transaction.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; private init; } = "refund";

    /// <summary>
    /// Gets or sets the service ID associated with the refund. 
    /// This is a unique identifier for the service involved in the refund transaction.
    /// </summary>
    [JsonPropertyName("serviceId")]
    public required string ServiceId { get; init; }

    /// <summary>
    /// Gets the amount of the refund. 
    /// The initializer converts the input amount from a major currency unit (e.g., dollars) to a minor unit (e.g., cents).
    /// </summary>
    [JsonPropertyName("amount")]
    public required int Amount
    {
        get => _amount;
        init => _amount = value * 100; 
    }
}
