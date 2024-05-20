namespace Axepta.SDK;

public enum PaymentMethodChannel
{
    #region pbs
    [Display(Name = "bnpparibas")]
    Bnpparibas,

    [Display(Name = "mtransfer")]
    Mtransfer,

    [Display(Name = "bzwbk")]
    Bzwbk,

    [Display(Name = "pekao24")]
    Pekao24,

    [Display(Name = "inteligo")]
    Inteligo,

    [Display(Name = "ing")]
    Ing,

    [Display(Name = "ipko")]
    Ipko,

    [Display(Name = "getin")]
    Getin,

    [Display(Name = "creditAgricole")]
    CreditAgricole,

    [Display(Name = "alior")]
    Alior,

    [Display(Name = "pbs")]
    Pbs,

    [Display(Name = "millennium")]
    Millennium,

    [Display(Name = "citi")]
    Citi,

    [Display(Name = "bos")]
    Bos,

    [Display(Name = "pocztowy")]
    Pocztowy,

    [Display(Name = "plusbank")]
    Plusbank,

    [Display(Name = "bs")]
    Bs,

    [Display(Name = "bspb")]
    Bspb,

    [Display(Name = "nest")]
    Nest,
    #endregion

    #region card
    [Display(Name = "ecom3ds")]
    Ecom3ds,

    [Display(Name = "oneclick")]
    Oneclick,

    [Display(Name = "recurring")]
    Recurring,
    #endregion

    #region blik
    [Display(Name = "blik")]
    Blik
    #endregion
}
