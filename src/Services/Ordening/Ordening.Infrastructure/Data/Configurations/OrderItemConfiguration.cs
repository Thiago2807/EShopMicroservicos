using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordening.Domain.Models;
using Ordening.Domain.ValueObjects;

namespace Ordening.Infrastructure.Data.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(pk => pk.Id);
        builder.Property(o => o.Id).HasConversion(
            orderItemId => orderItemId.Value, dbId => OrderItemId.Of(dbId));

        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(o => o.ProductId);


        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(o => o.OrderId);

        builder.Property(c => c.Quantity).IsRequired();
        builder.Property(c => c.Price).IsRequired();
    }
}
