namespace Axepta.SDK;

public enum OrderStatus : byte
{
    New,
    Pending,
    Rejected,
    Settled,
    Error,
    Cancelled
}