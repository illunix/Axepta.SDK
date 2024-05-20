namespace Axepta.SDK;

public enum OrderStatus : byte
{
    [Display(Name = "new")]
    New,

    [Display(Name = "pending")]
    Pending,

    [Display(Name = "rejected")]
    Rejected,

    [Display(Name = "settled")]
    Settled,

    [Display(Name = "error")]
    Error,

    [Display(Name = "cancelled")]
    Cancelled
}
