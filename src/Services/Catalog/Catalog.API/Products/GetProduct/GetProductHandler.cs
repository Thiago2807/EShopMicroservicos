
namespace Catalog.API.Products.GetProduct;

public record GetProductsQuery() : IQuery<GetProductResult>;

public record GetProductResult(IEnumerable<Product> Products);

internal class GetProductHandler(IDocumentSession session)
    : IQueryHandler<GetProductsQuery, GetProductResult>
{
    public async Task<GetProductResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>().ToListAsync();

        return new(products);
    }
}
