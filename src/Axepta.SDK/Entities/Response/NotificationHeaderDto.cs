namespace Axepta.SDK.Entities.Response;

internal sealed record NotificationHeaderDto(
    [property: JsonPropertyName("merchantid")] string MerchantId,
    [property: JsonPropertyName("serviceid")] string ServiceId,
    [property: JsonPropertyName("signature")] string Signature,
    [property: JsonPropertyName("alg")] string Algorithm
)
{
    public static NotificationHeaderDto FromString(string input)
    {
        var keyValuePairs = input.Split(';')
            .Select(part => part.Split('='))
            .ToDictionary(split => split[0], split => split[1]);

        return new NotificationHeaderDto(
            keyValuePairs["merchantid"],
            keyValuePairs["serviceid"],
            keyValuePairs["signature"],
            keyValuePairs["alg"]
        );
    }
}