namespace Axepta.SDK;

public static class Extensions
{
    public static IServiceCollection AddAxeptaPaywall(this IServiceCollection services)
    {
        services.AddHttpClient<IAxepta, Services.Axepta>(q =>
        {
            q.BaseAddress = new("https://paywall.axepta.pl");
            q.DefaultRequestHeaders.Accept.Add(new("application/json"));
            q.DefaultRequestHeaders.TryAddWithoutValidation(
                "Content-Type",
                "application/json; charset=utf-8"
            );
        })
            .AddPolicyHandler(HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(q => q.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(
                    6,
                    q => TimeSpan.FromSeconds(Math.Pow(
                        2,
                        q
                    ))
                )
            );

        return services;
    }
    internal static async Task PostAsync<T>(
        this HttpClient http,
        string url,
        T body,
        JsonTypeInfo<T> bodyCtx,
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
                        bodyCtx
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
            throw new AxeptaException(await httpRes!.Content.ReadAsStringAsync());
        }
    }
}