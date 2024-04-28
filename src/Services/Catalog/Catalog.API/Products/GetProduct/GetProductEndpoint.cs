﻿namespace Catalog.API.Products.GetProduct;

public record GetProductsRequest(int? PageNumber = 1, int? PageSize = 10);
public record GetProductResponse(IEnumerable<Product> Products);

public class GetProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async ([AsParameters] GetProductsRequest request, ISender sender) =>
        {
            var query = request.Adapt<GetProductsQuery>();

            var result = await sender.Send(query);

            var response = result.Adapt<GetProductResponse>();

            return Results.Ok(response);
        })
        .WithName("ObterProdutos")
        .Produces<GetProductResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Obter Produtos")
        .WithDescription("Obter os detalhes dos produtos em geral.");
    }
}
