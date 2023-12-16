namespace Axepta.SDK.Services.Abstractions;

public interface IAxepta
{
    Task<ResponseRoot> CreatePaymentAsync(
        Payment payment,
        CancellationToken ct = default
    );

    Task<ResponseRoot> CreateRefundAsync(
        Guid paymentId,
        Refund refund,
        CancellationToken ct = default
    );
}