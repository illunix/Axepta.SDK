using Axepta.SDK;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddAxeptaPaywall(builder.Configuration);

var app = builder.Build();

var paymentEndpoints = app.MapGroup("payments");

paymentEndpoints.MapPost(
    "/",
    async (
        IAxepta axepta,
        CancellationToken ct
    ) =>
    {
        var payment = await axepta.CreatePaymentAsync(
            new()
            {
                Type = PaymentType.Sale,
                ServiceId = "eff3207f-d2a0-4560-99ce-bba83267c90b",
                Amount = 100,
                Currency = "PLN",
                OrderId = "123456789",
                PaymentMethod = PaymentMethod.Pbl,
                PaymentMethodChannel = PaymentMethodChannel.Ipko,
                SuccessReturnUrl = "https://example.com/success",
                FailureReturnUrl = "https://example.com/failure",
                ReturnUrl = "https://example.com",
                ClientIp = "192.168.10.2",
                Customer = new()
                {
                    Id = "123",
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    Email = "jan.kowalski@example.com"
                }
            },
            ct
        );

        return Results.Ok(payment);
    }
);

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
