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
        CancellationToken ct = default
    )
    {
        HttpResponseMessage? httpRes = null;

        var httpResContentAsJson = async () => httpRes is null ?
            string.Empty :
            await httpRes.Content.ReadAsStringAsync(ct);

        try
        {
            var json = JsonSerializer.Serialize(
                body,
                _sourceGenOptions
            );

            httpRes = await http
                .PostAsync(
                    url,
                    new StringContent(
                        json,
                        Encoding.UTF8,
                        "application/json"
                    ),
                    ct
                )
                .ConfigureAwait(false);

            httpRes.EnsureSuccessStatusCode();

            return (K)JsonSerializer.Deserialize(
                await httpResContentAsJson().ConfigureAwait(false),
                typeof(K),
                _sourceGenOptions
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
                        await httpResContentAsJson().ConfigureAwait(false),
                        typeof(ResponseRoot),
                        _sourceGenOptions
                    )! as ResponseRoot;

                    throw new AxeptaException(resBody?.Data.ValidationErrors);
                }
                default:
                    throw new AxeptaException(await httpResContentAsJson().ConfigureAwait(false));
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