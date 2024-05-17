namespace Axepta.SDK.Services;

internal sealed class AxeptaNotification(IOptions<AxeptaPaywallOptions> options) : IAxeptaNotification
{
    public async Task<bool> HasValidSignature(HttpContext ctx)
    {
        var dto = NotificationHeaderDto.FromString(ctx.Request.Headers["X-Axepta-Signature"].ToString());

        using var reader = new StreamReader(ctx.Request.Body);

        var body = await reader.ReadToEndAsync();

        reader.Close();

        return dto.Signature == ComputeSha256Hash(body + "XrvZlCclg45zOOBtANK5reKo4onNlMrKAwgM");
    }

    private string ComputeSha256Hash(string data)
    {
        using SHA256 sha256Hash = SHA256.Create();
        var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(data));

        var builder = new StringBuilder();
        foreach (var t in bytes)
        {
            builder.Append(t.ToString("x2"));
        }
        return builder.ToString();
    }
}