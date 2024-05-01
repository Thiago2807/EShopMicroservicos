namespace Basket.API.Basket.DeleteBasket;

public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketResult>;
public record DeleteBasketResult(bool IsSucesso);

public class DeleteBasketCommandValidation : AbstractValidator<DeleteBasketCommand>
{
    public DeleteBasketCommandValidation() => RuleFor(x => x.UserName).NotNull().WithMessage("UserName is required");
}

public class DeleteBasketHandler
    : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
{
    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
    {
        // TODO: Excluir do banco de dados e excluir do cache

        return new DeleteBasketResult(true);
    }
}
