namespace Axepta.SDK;

public sealed class AxeptaResponseRoot
{
    [JsonPropertyName("status")]
    public required string Status { get; set; }

    [JsonPropertyName("data")]
    public required Data Data { get; set; }
}