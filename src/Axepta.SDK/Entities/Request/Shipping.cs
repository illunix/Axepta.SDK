namespace Axepta.SDK.Entities.Request;

/// <summary>
/// Represents shipping information for a customer, inheriting properties from the <see cref="Billing"/> class.
/// Provides additional details specific to shipping, extending the base billing information.
/// </summary>
public sealed record Shipping : Billing;