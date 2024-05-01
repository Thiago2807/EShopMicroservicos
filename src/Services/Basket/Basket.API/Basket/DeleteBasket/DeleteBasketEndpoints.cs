namespace Basket.API.Basket.DeleteBasket;

public record DeleteBasketRespose(bool IsSucesso);

public class DeleteBasketEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/basket/{userName}", async (string userName, ISender sender) =>
        {
            var response = await sender.Send(new DeleteBasketCommand(userName));

            var result = response.Adapt<DeleteBasketRespose>();

            return Results.Ok(result);
        })
        .WithName("DeleteProduct")
        .Produces<DeleteBasketRespose>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Product")
        .WithDescription("Delete Product");
    }
}
