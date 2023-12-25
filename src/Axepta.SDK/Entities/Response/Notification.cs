namespace Axepta.SDK;

public sealed record Notification
{
    [JsonPropertyName("payment")]
    public required Payment Payment { get; init; }
}