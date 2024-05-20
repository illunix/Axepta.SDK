namespace Axepta.SDK.JSON;

[JsonSerializable(typeof(Payment))]
[JsonSerializable(typeof(ResponseRoot))]
[JsonSerializable(typeof(Notification))]
internal sealed partial class JsonContext : JsonSerializerContext { }