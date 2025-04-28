namespace Axepta.SDK.Services;

internal sealed class Axepta(
    HttpClient http,
    IOptions<AxeptaPaywallOptions> options
 ) : IAxepta
{
    public Task<AxeptaResponseRoot> CreatePaymentAsync(
        Payment payment,
        CancellationToken ct = default
    )
    {
        payment.SetServiceId(options.Value.Service.Id);
        return http.PostAsync<Payment, AxeptaResponseRoot>(
            "transaction",
            payment,
            ct
        );
    }

    public Task<AxeptaResponseRoot> CreatePaymentUrlAsync(
        GeneratePaymentLink paymentLink,
        CancellationToken ct = default
    )
    {
        paymentLink.SetServiceId(options.Value.Service.Id);
        return http.PostAsync<GeneratePaymentLink, AxeptaResponseRoot>(
           "payment-link",
           paymentLink,
           ct
       );
    }

    public Task<AxeptaResponseRoot> CreateRefundAsync(
        Guid paymentId,
        Refund refund,
        CancellationToken ct = default
    )
    {
        refund.SetServiceId(options.Value.Service.Id);
        return http.PostAsync<Refund, AxeptaResponseRoot>(
            $"payment/{paymentId}/refund",
            refund,
            ct
        );
    }

    public async Task<Transaction> GetTransactionAsync(
        Guid transactionId,
        CancellationToken ct = default
    )
        => (await http.GetAsync<AxeptaResponseRoot>(
            $"transaction/{transactionId}",
            ct
        )).Data.Transaction!;

    public async Task<PaymentResponse> GetPaymentAsync(
        Guid paymentId,
        CancellationToken ct = default
    )
        => (await http.GetAsync<AxeptaResponseRoot>(
            $"payment/{paymentId}",
            ct
        )).Data.Payment!;
}