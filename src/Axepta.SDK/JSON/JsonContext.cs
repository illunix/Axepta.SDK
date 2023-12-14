namespace Axepta.SDK.JSON;

[JsonSerializable(typeof(Payment))]
[JsonSerializable(typeof(CreatePaymentResponse))]
internal sealed partial class JsonContext : JsonSerializerContext { }