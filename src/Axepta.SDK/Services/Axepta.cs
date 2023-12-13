﻿namespace Axepta.SDK.Services;

internal sealed class Axepta(
    HttpClient http,
    ISignatureService signatureService
) : IAxepta
{

    public async Task CreatePaymentAsync(
        Payment payment,
        CancellationToken ct = default
    )
        => await http.PostAsync(
            "payments",
            payment,
            JsonContext.Default.Payment,
            ct
        );
}