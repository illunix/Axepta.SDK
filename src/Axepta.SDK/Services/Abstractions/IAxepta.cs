namespace Axepta.SDK.Services.Abstractions;

public interface IAxepta
{
    Task<ResponseRoot> CreatePaymentAsync(
        Payment payment,
        CancellationToken ct = default
    );
}