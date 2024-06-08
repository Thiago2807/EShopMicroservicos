namespace Ordening.Domain.ValueObjects;

public class Orderid
{
    public Guid Value { get; }

    private Orderid(Guid value) => Value = value;

    public static Orderid Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (value == Guid.Empty)
            throw new DomainException("Orderid cannot be empty.");

        return new Orderid(value);
    }

}
