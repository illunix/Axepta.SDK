namespace Axepta.SDK;

public static class Extensions
{
    private static readonly JsonSerializerOptions _sourceGenOptions = new()
    {
        TypeInfoResolver = JsonContext.Default,
        Converters =
        {
            new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
        },
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public static IServiceCollection AddAxeptaPaywall(
        this IServiceCollection services,
        IConfiguration cfg
    )
    {
        var optionsSelection = cfg.GetSection(AxeptaPaywallOptions.SelectionName);

        services
            .AddOptions<AxeptaPaywallOptions>()
            .Bind(optionsSelection)
            .ValidateOnStart();

        var axeptaPaywallOptions = optionsSelection.Get<AxeptaPaywallOptions>();

        var axeptaUrl = axeptaPaywallOptions!.Sandbox ?
            "api.sandbox.axepta.pl" :
            "api.axepta.pl";

        services.AddHttpClient<IAxepta, Services.Axepta>(q =>
        {
            q.BaseAddress = new($"https://{axeptaUrl}/v1/merchant/{axeptaPaywallOptions.MerchantId}/");
            q.DefaultRequestHeaders.Accept.Add(new("application/json"));
            q.DefaultRequestHeaders.TryAddWithoutValidation(
                "Content-Type",
                "application/json; charset=utf-8"
            );
            q.DefaultRequestHeaders.Authorization = new(
                "Bearer",
                axeptaPaywallOptions.AuthToken
            );
        })
            .AddPolicyHandler(HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(q => q.StatusCode == HttpStatusCode.NotFound)
                .WaitAndRetryAsync(
                    2,
                    q => TimeSpan.FromSeconds(Math.Pow(
                        2,
                        q
                    ))
                )
            );

        return services;
    }

    internal static async Task<K> PostAsync<T, K>(
        this HttpClient http,
        string url,
        T body,
        JsonTypeInfo<K> jsonTypeInfoResponse,
        CancellationToken ct = default
    )
    {
        HttpResponseMessage? httpRes = null;

        var elo = JsonSerializer.Serialize(
            body,
            _sourceGenOptions
            );

        Console.WriteLine(elo);

        try
        {
            httpRes = await http.PostAsync(
                url,
                new StringContent(
                    JsonSerializer.Serialize(
                        body,
                        _sourceGenOptions
                    ),
                    Encoding.UTF8,
                    "application/json"
                ),
                ct
            );

            httpRes.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize(
                await httpRes.Content.ReadAsStringAsync(ct),
                jsonTypeInfoResponse
            )!;
        }
        catch (HttpRequestException)
        {
            switch (httpRes?.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    throw new AxeptaException("Authorization failed: The provided token is invalid, preventing authorized access to the requested resource.");
                case HttpStatusCode.UnprocessableEntity:
                {
                    var resBody = JsonSerializer.Deserialize(
                        await httpRes.Content.ReadAsStringAsync(ct),
                        typeof(ResponseRoot),
                        _sourceGenOptions
                    )! as ResponseRoot;

                    throw new AxeptaException(resBody?.Data.ValidationErrors);
                }
                default:
                    throw new AxeptaException(await httpRes!.Content.ReadAsStringAsync(ct));
            }
        }
    }

    internal static string FirstCharToUpper(this string input) =>
        input switch
    {
        null => throw new ArgumentNullException(nameof(input)),
        "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
        _ => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1))
    };
}