namespace Axepta.SDK.Tests;

public sealed class AxeptaSignatureValidatorTests
{
    private const string BODY = "";
    private const string INCOMING_SIGNATURE = "";
    private const string SHA256_ALG = "sha256";
    
    [Fact]
    public void IsValidSignature_WithCorrectSha256Signature_ReturnsTrue()
    {
        
    }

    [Fact]
    public void IsValidSignature_WithIncorrectSha256Signature_ReturnsFalse()
    {
    }

    [Theory]
    [InlineData("sha1")]
    [InlineData("md5")]
    [InlineData("")]
    [InlineData(null)]
    public void IsValidSignature_WithUnsupportedAlgorithm_ReturnsFalse(string alg)
    {
        
    }
}