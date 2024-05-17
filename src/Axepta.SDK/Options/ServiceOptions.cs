namespace Axepta.SDK.Options;

internal sealed record ServiceOptions
{
    public required string Id { get; init; }
    public required string Key { get; init; }
}