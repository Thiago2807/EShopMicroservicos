namespace Ordening.Application.Exceptions;

public class OrderNotFoundException(Guid id) : NotFoundException("Order", id);
