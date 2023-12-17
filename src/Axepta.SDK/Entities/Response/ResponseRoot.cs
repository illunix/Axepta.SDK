namespace Axepta.SDK;

public sealed class ResponseRoot
{
    [JsonPropertyName("status")]
    public required string Status { get; set; }

    [JsonPropertyName("data")]
    public required Data Data { get; set; }
}