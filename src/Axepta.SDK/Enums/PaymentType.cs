namespace Axepta.SDK;

public enum PaymentType : byte
{
    [Display(Name = "sale")]
    Sale,

    [Display(Name = "refund")]
    Refund
}
