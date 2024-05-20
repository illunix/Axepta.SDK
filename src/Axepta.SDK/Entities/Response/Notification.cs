namespace Axepta.SDK.Entities.Response;

public sealed record Notification
{
    [JsonPropertyName("payment")]
    public required NotificationPayment Payment { get; init; }
}