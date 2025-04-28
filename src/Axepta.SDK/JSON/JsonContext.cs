namespace Axepta.SDK.JSON;

[JsonSerializable(typeof(Payment))]
[JsonSerializable(typeof(GeneratePaymentLink))]
[JsonSerializable(typeof(AxeptaResponseRoot))]
[JsonSerializable(typeof(Notification))]
internal sealed partial class JsonContext : JsonSerializerContext { }