namespace Ordening.Application.Orders.Queries.GetIrderByCustomer;

public record GetIrderByCustomerQuery(Guid CustomerId) : IQuery<GetIrderByCustomerResult>;

public record GetIrderByCustomerResult(IEnumerable<OrderDto> Orders);
