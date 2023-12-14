using Axepta.SDK;
using Axepta.SDK.Enums;
using Axepta.SDK.Services.Abstractions;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddAxeptaPaywall();

var app = builder.Build();

var payment = app.MapGroup("payments");

payment.MapPost(
    "/",
    async (
        IAxepta axepta,
        CancellationToken ct
    ) =>
    {
        await axepta.CreatePaymentAsync(
            new()
            {
                Type = PaymentType.Sale,
                ServiceId = "62f574ed-d4ad-4a7e-9981-89ed7284aaba",
                Amount = 100,
                Currency = "PLN",
                OrderId = "123456789",
                PaymentMethod = PaymentMethod.Pbl,
                PaymentMethodChannel = "pbl",
                SuccessReturnUrl = "https://example.com/success",
                FailureReturnUrl = "https://example.com/failure",
                ReturnUrl = "https://example.com",
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

        return Results.Ok();
    }
);

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
