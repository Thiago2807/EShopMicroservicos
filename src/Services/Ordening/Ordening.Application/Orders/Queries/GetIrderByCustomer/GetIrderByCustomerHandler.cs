namespace Ordening.Application.Orders.Queries.GetIrderByCustomer;

public class GetIrderByCustomerHandler (IApplicationDbContext context)
    : IQueryHandler<GetIrderByCustomerQuery, GetIrderByCustomerResult>
{
    public async Task<GetIrderByCustomerResult> Handle(GetIrderByCustomerQuery query, CancellationToken cancellationToken)
    {
        var orders = await context.Orders
            .Include(o => o.OrderItems)
            .AsNoTracking()
            .Where(o => o.CustomerId == CustomerId.Of(query.CustomerId))
            .OrderBy(o => o.OrderName.Value)
            .ToListAsync(cancellationToken);

        return new GetIrderByCustomerResult(orders.ToOrderDtoList());
    }
}
