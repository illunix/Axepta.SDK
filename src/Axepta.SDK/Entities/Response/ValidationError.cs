namespace Axepta.SDK.Entities.Response;

public sealed record ValidationError
{
    private readonly string? _property;
    
    [JsonPropertyName("property")]
    public required string Property
    {
        get => _property!;
        init => _property = value
            .Replace(
                "instance.",
                string.Empty
            )
            .FirstCharToUpper();
    }
    
    [JsonPropertyName("message")]
    public required string Message { get; init; }
}