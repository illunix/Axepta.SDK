namespace Axepta.SDK.Entities.Response;

public sealed class ResponseRoot
{
    [JsonPropertyName("status")]
    public required string Status { get; set; }

    [JsonPropertyName("data")]
    public required Data Data { get; set; }
}