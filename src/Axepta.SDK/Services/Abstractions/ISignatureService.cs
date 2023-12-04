namespace Axepta.SDK.Services.Abstractions;

internal interface ISignatureService
{
    string CalculateSignature(
        Dictionary<string, string> orderParams,
        string privateKey
    );
}