using BuildingBlocks.CQRS;

namespace Ordening.Application.Orders.Commands.CreateOrder;

public class CreateOrderHandler : ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    public Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        // create Order entity from command object
        // save to database
        // return result

        throw new NotImplementedException();
    }
}
