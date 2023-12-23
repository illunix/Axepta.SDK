namespace Axepta.SDK.Services;

internal sealed class Axepta(HttpClient http) : IAxepta
{
    public Task<ResponseRoot> CreatePaymentAsync(
        Payment payment,
        CancellationToken ct = default
    )
        => http.PostAsync<Payment, ResponseRoot>(
            "transaction",
            payment,
            ct
        );

    public Task<ResponseRoot> CreateRefundAsync(
        Guid paymentId,
        Refund refund,
        CancellationToken ct = default
    )
        => http.PostAsync<Refund, ResponseRoot>(
            $"payment/{paymentId}/refund",
            refund,
            ct
        );

    public IImmutableDictionary<string, IImmutableList<string>> GetPaymentMethods()
        => PaymentMethod.List();
}