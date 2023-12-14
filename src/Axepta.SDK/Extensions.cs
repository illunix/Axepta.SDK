namespace Axepta.SDK;

public static class Extensions
{
    private static JsonSerializerOptions _sourceGenOptions = new JsonSerializerOptions
    {
        TypeInfoResolver = JsonContext.Default,
        Converters =
        {
            new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
        }
    };

    public static IServiceCollection AddAxeptaPaywall(this IServiceCollection services)
    {
        services.AddHttpClient<IAxepta, Services.Axepta>(q =>
        {
            q.BaseAddress = new("https://api.axepta.pl/v1/merchant/ir49nkdgnuex458f6wnq");
            q.DefaultRequestHeaders.Accept.Add(new("application/json"));
            q.DefaultRequestHeaders.TryAddWithoutValidation(
                "Content-Type",
                "application/json; charset=utf-8"
            );
            q.DefaultRequestHeaders.Authorization = new(
                "Bearer",
                "ttfc9ve4zeseca4egs0pguk15c3yckkwf7d1n1ts8e55y5hs68886ujt76z5glbl"
            );
        })
            .AddPolicyHandler(HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(q => q.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(
                    2,
                    q => TimeSpan.FromSeconds(Math.Pow(
                        2,
                        q
                    ))
                )
            );

        services.AddSingleton<ISignatureService, SignatureService>();

        return services;
    }
 
    internal static async Task PostAsync<T>(
        this HttpClient http,
        string url,
        T body,
        CancellationToken ct 
    )
    {
        HttpResponseMessage? httpRes = null;

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
        }
        catch (HttpRequestException)
        {
            throw new AxeptaException(await httpRes!.Content.ReadAsStringAsync(ct));
        }
    }

    public static async Task<K> PostAsync<T, K>(
        this HttpClient http,
        string url,
        T body,
        JsonTypeInfo<K> jsonTypeInfoResponse,
        CancellationToken ct = default
    )
    {
        HttpResponseMessage? httpRes = null;

        try
        {
            var elo = JsonSerializer.Serialize(
                body,
                _sourceGenOptions
            );
                 
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
            var elo = httpRes!.Content.ReadAsStringAsync();

            throw new AxeptaException(await httpRes!.Content.ReadAsStringAsync(ct));
        }
    }
}