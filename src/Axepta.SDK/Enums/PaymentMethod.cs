namespace Axepta.SDK;

public abstract class PaymentMethod
{
    public static readonly PaymentMethod Pbl = new PblPaymentMethod();
    public static readonly PaymentMethod Card = new CardPaymentMethod();
    public static readonly PaymentMethod Blik = new BlikPaymentMethod();

    internal static IImmutableDictionary<string, IImmutableList<string>> List()
        => new Dictionary<string, IImmutableList<string>>
        {
            { nameof(Pbl), Pbl.Channels },
            { nameof(Card), Card.Channels },
            { nameof(Blik), Blik.Channels }
        }.ToImmutableDictionary();

    protected PaymentMethod(
        byte value,
        string name
    ) { }

    public abstract ImmutableArray<string> ChannelNames { get; }

    public sealed class PblPaymentMethod : PaymentMethod
    {
        public PblPaymentMethod() : base(
            1,
            nameof(Pbl)
        ) { }

        public static class Channels
        {
            public static readonly (
                string,
                string
            ) BnpParibas = (
                "BNP Paribas",
                ""
            );
        }

        public override ImmutableArray<string> ChannelNames
            => ImmutableArray.Create(
                "BNP Paribas",
                "mTransfer",
                "Santander Bank",
                "Pekao24",
                "Inteligo",
                "ING Bank Śląski",
                "iPKO",
                "Getin Bank",
                "Credit Agricole",
                "Alior Bank",
                "Podkarpacki Bank Spółdzielczy",
                "Millennium",
                "Citibank",
                "Bank Ochrony Środowiska",
                "Bank Pocztowy",
                "Plusbank",
                "Bs",
                "Bspb",
                "Nest Bank"
            );
    }

    private sealed class CardPaymentMethod : PaymentMethod
    {
        public CardPaymentMethod() : base(
            2,
            nameof(Card)
        ) { }

        public override ImmutableArray<string> Channels
            => ImmutableArray.Create(
                "Ecom 3DS",
                "One click",
                "Recurring"
            );
    }

    private sealed class BlikPaymentMethod : PaymentMethod
    {
        public BlikPaymentMethod() : base(
            3,
            nameof(Blik)
        ) { }

        public override ImmutableArray<string> Channels
            => ImmutableArray.Create("Blik");
    }
}

/*
public enum PaymentMethod : byte
{
    Pbl,
    Card,
    Blik,
    BnpInstalments
}
*/

/*
public enum PaymentMethod
{
    Pbl(new[] { }),
    Card(new[] { PaymentMethodChannel.Ecom3ds, PaymentMethodChannel.Oneclick, PaymentMethodChannel.Recurring }),
    Blik(new[] { PaymentMethodChannel.Blik }),

    private PaymentMethodChannel[] channels;

private PaymentMethod(PaymentMethodChannel[] channels)
{
    this.channels = channels;
}

public PaymentMethodChannel[] GetChannels() => channels;
}
*/