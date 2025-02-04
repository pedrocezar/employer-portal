namespace EmployerPortal.Domain.Errors;

public abstract class DomainError : Exception
{
    protected DomainError(string message) : base(message)
    {
    }
} 