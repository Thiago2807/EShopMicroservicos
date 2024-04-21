
namespace Catalog.API.Products.GetProduct;

public record GetProductsQuery() : IQuery<GetProductResult>;

public record GetProductResult(IEnumerable<Product> Products);

internal class GetProductHandler(IDocumentSession session, ILogger<GetProductHandler> logger)
    : IQueryHandler<GetProductsQuery, GetProductResult>
{
    public async Task<GetProductResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductHandler.Handle called with {@Query}", query);

        var products = await session.Query<Product>().ToListAsync();

        return new(products);
    }
}
