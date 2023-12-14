namespace Axepta.SDK.Entities.Request;

/// <summary>
/// Represents additional data associated with a payment, including browser information.
/// </summary>
public sealed record AdditionalData
{
    /// <summary>
    /// Gets or initializes browser information associated with the additional data.
    /// </summary>
    [JsonPropertyName("browser")]
    public required Browser Browser { get; init; }
}
