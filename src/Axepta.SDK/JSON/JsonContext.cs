namespace Axepta.SDK.JSON;

[JsonSerializable(typeof(Payment))]
[JsonSerializable(typeof(ResponseRoot))]
internal sealed partial class JsonContext : JsonSerializerContext { }