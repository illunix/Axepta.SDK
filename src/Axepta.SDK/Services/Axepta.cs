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

    public async Task<Transaction> GetTransactionAsync(
        Guid transationId,
        CancellationToken ct = default
    )
        => (await http.GetAsync<ResponseRoot>(
            $"transaction/{transationId}",
            ct
        )).Data.Transaction!;

    public async Task<PaymentResponse> GetPaymentAsync(
        Guid paymentId,
        CancellationToken ct = default
    )
        => (await http.GetAsync<ResponseRoot>(
            $"payment/{paymentId}",
            ct
        )).Data.Payment!;
}