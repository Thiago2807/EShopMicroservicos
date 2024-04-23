﻿
using Catalog.API.Products.UptadeProduct;

namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;
public record DeleteProductResult(bool IsSuccess);

public class DeleteProductCommandValidatior : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidatior()
        => RuleFor(command => command.Id).NotEmpty().WithMessage("Product ID is required.");
}

public class DeleteProductHandler(IDocumentSession session, ILogger<DeleteProductHandler> logger)
    : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("DeleteProductHandler.Handle called with {@Query}", command);

        session.Delete<Product>(command.Id);
        await session.SaveChangesAsync(cancellationToken);

        return new(true);
    }
}
