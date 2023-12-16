namespace Axepta.SDK.Services;

internal sealed class Axepta(HttpClient http) : IAxepta
{
    public Task<ResponseRoot> CreatePaymentAsync(
        Payment payment,
        CancellationToken ct = default
    )
        => http.PostAsync(
            "transaction",
            payment,
            JsonContext.Default.ResponseRoot,
            ct
        );

    public Task<ResponseRoot> CreateRefundAsync(
        Guid paymentId,
        Refund refund,
        CancellationToken ct = default
    )
        => http.PostAsync(
            $"payment/{paymentId}/refund",
            refund,
            JsonContext.Default.ResponseRoot,
            ct
        );
}