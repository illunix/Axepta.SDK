namespace Axepta.SDK;

public interface IAxeptaNotification
{
    Task<bool> HasValidSignature(HttpContext ctx);
}