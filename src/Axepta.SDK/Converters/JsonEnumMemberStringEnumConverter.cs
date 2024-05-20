namespace Axepta.SDK.Converters;

public class JsonEnumMemberStringEnumConverter(JsonNamingPolicy? namingPolicy = null, bool allowIntegerValues = true)
    : JsonConverterFactory
{
    private readonly JsonStringEnumConverter baseConverter = new(namingPolicy, allowIntegerValues);

    public JsonEnumMemberStringEnumConverter() : this(null, true) { }

    public override bool CanConvert(Type typeToConvert) => baseConverter.CanConvert(typeToConvert);

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var query = from field in typeToConvert.GetFields(BindingFlags.Public | BindingFlags.Static)
            let attr = field.GetCustomAttribute<DisplayAttribute>()
            where attr != null && attr.Name != null
            select (field.Name, attr.Name);
        var dictionary = query.ToDictionary(p => p.Item1, p => p.Item2);
        return dictionary.Count > 0 ? new JsonStringEnumConverter(new DictionaryLookupNamingPolicy(dictionary, namingPolicy), allowIntegerValues).CreateConverter(typeToConvert, options) : baseConverter.CreateConverter(typeToConvert, options);
    }
}

public class JsonNamingPolicyDecorator(JsonNamingPolicy? underlyingNamingPolicy) : JsonNamingPolicy
{
    public override string ConvertName(string name) => underlyingNamingPolicy?.ConvertName(name) ?? name;
}

internal class DictionaryLookupNamingPolicy(
    Dictionary<string, string> dictionary,
    JsonNamingPolicy? underlyingNamingPolicy)
    : JsonNamingPolicyDecorator(underlyingNamingPolicy)
{
    readonly Dictionary<string, string> dictionary = dictionary ?? throw new ArgumentNullException();

    public override string ConvertName(string name) => dictionary.TryGetValue(name, out var value) ? value : base.ConvertName(name);
}
