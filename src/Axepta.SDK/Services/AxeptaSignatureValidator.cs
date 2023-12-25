namespace Axepta.SDK;

internal sealed class AxeptaSignatureValidator : IAxeptaSignatureValidator
{
    public bool IsValidSignature(
        string incomingSignature,
        string body,
        string alg
    )
    {
        if (alg is "sha256")
        {
            using var sha256Hash = SHA256.Create();
            
            var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(body));
            var builder = new StringBuilder();
            
            for (var i = 0; i < bytes.Length; i++)
                builder.Append(bytes[i].ToString("x2"));
            
            var signature = builder.ToString();
            
            return signature == incomingSignature;
        }
        
        return false;
    }
}