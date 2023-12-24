namespace Axepta.SDK;

public sealed record TransactionResponse
{
    [JsonPropertyName("data")]
    public required Data Data { get; init; }
}