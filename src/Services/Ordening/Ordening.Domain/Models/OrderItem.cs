using Ordening.Domain.Abstractions;

namespace Ordening.Domain.Models;

public class OrderItem : Entity<OrderItemId>
{
    public OrderItem(Orderid orderId, ProductId productId, int quantity, decimal price)
    {
        Id = OrderItemId.Of(Guid.NewGuid());
        Price = price;
        OrderId = orderId;
        Quantity = quantity;
        ProductId = productId;
    }

    public Orderid OrderId { get; private set; } = default!;
    public ProductId ProductId { get; private set; } = default!;
    public int Quantity { get; private set; } = default!;
    public decimal Price { get; private set; } = default!;
}
