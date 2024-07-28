namespace Ordening.Domain.ValueObjects;

public class OrderName
{
    private const int DefaultLength = 5;
    public string Value { get; } = default!;

    private OrderName(string value) => Value = value;

    public static OrderName Of(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        return new OrderName(value);
    }
}
