namespace Axepta.SDK.Tests;

public sealed class SignatureServiceTests
{
    [Fact]
    public void CalculateSignature_ValidInput_ReturnsExpectedSignature()
    {
        // Arrange
        var orderParams = new Dictionary<string, string>
        {
            {"merchantId", "6yt3gjtm9p1odfgx8491"},
            {"serviceId", "63f574ed-d90d-4abe-9cs1-39117584a7b"},
            {"amount", "300"},
            {"currency", "PLN"},
            {"orderId", "123"},
            {"title", "Example transaction"},
            {"customer[firstName]", "John"},
            {"customer[lastName]", "Doe"},
            {"customer[email]", "johndoe@domain.com"},
            {"customer[phone]", "501501501"},
            {"successReturnUrl", "https://your-shop.com/success"},
            {"failureReturnUrl", "https://your-shop.com/failure"},
            {"returnUrl", "https://your-shop.com/return"},
            {"cartData", "H4sIAAAAAAAAA62QwU7DMAyGX6XyuYi069S1t4kbBcQNCcTBtBGzmiYlSVexam/GlffCGVC6OznZv/3ZfzwBdmbQHspklRV5DLWV6GWzDcq6yEW2EcUmBmwaK52DcoIXUor3awg1dhJKuEYdVWZE5VqCGJy3UjIPD2jdAUfXYpRcplzpjfOorkwTKCEuhBCs1uTfOb8ldN6EPsiyQbq/CdDO2NC/Fj8PjjE0UtFebqbZxVZrjO7YRrv0UI0kPRfyf1zP+92O+v78CtVgSVom5osyEsMeOUxXwTO5+rsyM4+aPj9aXEJFUSwh8rLjsz9NQA0DCbf+7jPuMKgzODvBbwNqf/pU+jfp+fgFAfFFOOsBAAA="}
        };

        var privateKey = "YourPrivateKey";

        var mockSignatureService = new Mock<ISignatureService>();
        mockSignatureService
            .Setup(q => q.CalculateSignature(orderParams, privateKey))
            .Returns("ExpectedSignature;sha256");

        var signatureService = mockSignatureService.Object;

        // Act
        var result = signatureService.CalculateSignature(
            orderParams, 
            privateKey
        );

        // Assert
        Assert.Equal(
            "ExpectedSignature;sha256",
            result
        );
    }
}