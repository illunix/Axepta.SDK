namespace Axepta.SDK.Options;

internal sealed record AxeptaPaywallOptions
{
    public const string SelectionName = "axepta-paywall";
    
    public required string MerchantId { get; init; }
    public required string AuthToken { get; init; }
    public required bool Sandbox { get; init; }
}