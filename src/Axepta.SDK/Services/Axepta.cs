namespace Axepta.SDK.Services;

internal sealed class Axepta(
    HttpClient http,
    IOptions<AxeptaPaywallOptions> options
 ) : IAxepta
{
    public Task<ResponseRoot> CreatePaymentAsync(
        Payment payment,
        CancellationToken ct = default
    )
    {
        payment.SetServiceId(options.Value.Service.Id);
        return http.PostAsync<Payment, ResponseRoot>(
            "transaction",
            payment,
            ct
        );
    }

    public Task<ResponseRoot> CreateRefundAsync(
        Guid paymentId,
        Refund refund,
        CancellationToken ct = default
    )
    {
        refund.SetServiceId(options.Value.Service.Id);
        return http.PostAsync<Refund, ResponseRoot>(
            $"payment/{paymentId}/refund",
            refund,
            ct
        );
    }

    public async Task<Transaction> GetTransactionAsync(
        Guid transactionId,
        CancellationToken ct = default
    )
        => (await http.GetAsync<ResponseRoot>(
            $"transaction/{transactionId}",
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