namespace Axepta.SDK;

public interface IAxeptaNotification
{
    Task<(bool, Notification)> HasValidSignature(HttpContext ctx);
}