namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<CreateProductResult>;
public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler (IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product()
        {
            Name = command.Name,
            Price = command.Price,
            Category = command.Category,
            ImageFile = command.ImageFile,
            Description = command.Description,
        };

        // Salvar no banco de dados
        session.Store(product); // Caso não tenha uma tabela para 'Product' ele simplesmente vai criar uma automaticamente
        await session.SaveChangesAsync();

        return new CreateProductResult(product.Id);
    }
}
 