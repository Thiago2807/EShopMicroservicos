using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data;

public class DiscountContext(DbContextOptions<DiscountContext> options) : DbContext(options)
{
    public DbSet<Coupon> Coupons { get; set; } = default!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Coupon>().HasData(
                new() { Id = 1, ProductName = "Iphone X", Description= "IPhone Discount", Amount = 150 },
                new() { Id = 2, ProductName = "Samsung 10", Description = "Samsung Discount", Amount = 100 }
            );
    }
}
