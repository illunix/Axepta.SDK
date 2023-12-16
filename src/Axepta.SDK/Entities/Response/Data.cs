namespace Axepta.SDK.Entities.Response;

public sealed record Data
{
    [JsonPropertyName("transaction")]
    public Transaction? Transaction { get; init; }

    [JsonPropertyName("action")]
    public Action? Action { get; init; }

    [JsonPropertyName("validatorErrors")]
    public IReadOnlyList<ValidationError>? ValidationErrors { get; init; }
}