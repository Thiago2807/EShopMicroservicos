namespace Ordening.Application.Orders.Queries.GetOrdersByName;

public record GetOrdersByNameQuery(string Name) : IQuery<GetOrdersByNameResult>;
public record GetOrdersByNameResult(IEnumerable<OrderDto> Orders);

public class GetOrdersByNameQueryValidator : AbstractValidator<GetOrdersByNameQuery>
{
    public GetOrdersByNameQueryValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
    }
}