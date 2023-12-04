namespace Axepta.SDK.Services;

internal sealed class SignatureService : ISignatureService
{
    public string CalculateSignature(
        Dictionary<string, string> orderParams,
        string privateKey
    )
    {
        var sortedParams = orderParams.OrderBy(p => p.Key);
        var body = string.Join(
            "&", 
            sortedParams.Select(p => $"{p.Key}={p.Value}")
        );
        var signature = CalculateSha256Hash(body + privateKey);

        signature += ";sha256";

        return signature;
    }

    private string CalculateSha256Hash(string input)
    {
        using var sha256 = SHA256.Create();
        var inputBytes = Encoding.UTF8.GetBytes(input);
        var hashBytes = sha256.ComputeHash(inputBytes);

        var builder = new StringBuilder();
        for (var i = 0; i < hashBytes.Length; i++)
            builder.Append(hashBytes[i].ToString("x2"));

        return builder.ToString();
    }
}