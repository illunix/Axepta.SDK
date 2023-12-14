using Payment = Axepta.SDK.Entities.Request.Payment;

namespace Axepta.SDK.Services.Abstractions;

public interface IAxepta
{
    Task<CreatePaymentResponse> CreatePaymentAsync(
        Payment payment,
        CancellationToken ct = default
    );
}