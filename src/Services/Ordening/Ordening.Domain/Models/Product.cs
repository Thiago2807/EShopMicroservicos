using Ordening.Domain.Abstractions;

namespace Ordening.Domain.Models;

public class Product : Entity<ProductId>
{
    public string Name { get; private set; } = default!;
    public decimal Price { get; private set; } = default!;
}
