namespace Axepta.SDK.Services.Abstractions;

public interface ISignatureService
{
    string CalculateSignature(
        Dictionary<string, string> orderParams,
        string privateKey
    );
}