namespace Axepta.SDK.Entities;

public sealed record PayWall
{
    [JsonPropertyName("forceCardChannel")]
    public string? ForceCardChannel { get; init; }
}
