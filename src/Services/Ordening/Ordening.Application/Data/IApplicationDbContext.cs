﻿using Microsoft.EntityFrameworkCore;
using Ordening.Domain.Models;

namespace Ordening.Application.Data;

public interface IApplicationDbContext
{
    public DbSet<Customer> Customers { get; }
    public DbSet<Product> Products { get; }
    public DbSet<Order> Orders { get; }
    public DbSet<OrderItem> OrderItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}
