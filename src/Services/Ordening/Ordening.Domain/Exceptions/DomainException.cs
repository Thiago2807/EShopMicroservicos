namespace Ordening.Domain.Exceptions;

public class DomainException(string message) 
    : Exception($"Domain Excetion: \"{message}\" throws from Domain Layer.");
