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
}