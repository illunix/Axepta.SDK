namespace Axepta.SDK.Entities.Response;

public class NotifyTransactionData
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("type")]
    public required string Type { get; set; }
}