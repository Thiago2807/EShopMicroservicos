namespace Catalog.API.Products.GetProductById;

public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;
public record GetProductByIdResult(Product Product);

public class GetProductByIdHandler(IDocumentSession session, ILogger<GetProductByIdHandler> logger) 
    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductByIdHandler.Handle called with {@Query}", query);

        var result = await session.LoadAsync<Product>(query.Id, cancellationToken) ?? throw new ProductNotFoundException();

        return new GetProductByIdResult(result);
    }
}
