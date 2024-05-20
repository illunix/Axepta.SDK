namespace Axepta.SDK;

public enum PaymentMethod : byte
{
    [Display(Name = "pbl")]
    Pbl,

    [Display(Name = "card")]
    Card,

    [Display(Name = "blik")]
    Blik,

    [Display(Name = "bnpInstalments")]
    BnpInstalments
}
