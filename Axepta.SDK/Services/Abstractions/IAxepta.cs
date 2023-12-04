namespace Axepta.SDK;

public interface IAxepta
{
    Task CreatePaymentAsync(
        Payment payment,
        CancellationToken ct = default
    );
}