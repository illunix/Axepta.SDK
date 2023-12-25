namespace Axepta.SDK;

public sealed record NotificationTransactionData
{
    [JsonPropertyName("id")]
    public required Guid Id { get; init; }

    [JsonPropertyName("type")]
    public required string Type { get; init; }
}