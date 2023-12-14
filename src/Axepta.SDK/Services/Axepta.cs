namespace Axepta.SDK.Services;

internal sealed class Axepta(HttpClient http) : IAxepta
{
    public async Task<CreatePaymentResponse> CreatePaymentAsync(
        Payment payment,
        CancellationToken ct = default
    )
        => await http.PostAsync(
            $"transaction",
            payment,
            JsonContext.Default.CreatePaymentResponse,
            ct
        );
}