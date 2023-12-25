namespace Axepta.SDK;

internal interface IAxeptaSignatureValidator
{
    bool IsValidSignature(
        string signature,
        string body,
        string alg
    );
}