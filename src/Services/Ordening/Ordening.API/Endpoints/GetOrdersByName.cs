using Ordening.Application.Orders.Commands.DeleteOrder;
using Ordening.Application.Orders.Queries.GetOrdersByName;

namespace Ordening.API.Endpoints;

public record GetOrdersByNameResponse(IEnumerable<OrderDto> OrderDtos);

public class GetOrdersByName : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders/{orderName}", async (string OrderName, ISender sender) =>
        {
            var result = await sender.Send(new GetOrdersByNameQuery(OrderName));

            var response = result.Adapt<DeleteOrderResponse>();

            return Results.Ok(response);
        })
        .WithName("GetOrdersByName")
        .Produces<GetOrdersByNameResponse>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status404NotFound)
        .WithSummary("Get Orders By Name")
        .WithDescription("Get Orders By Name");
    }
}
