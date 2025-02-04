namespace EmployerPortal.Domain.Errors;

public class NotFoundError : DomainError
{
    public NotFoundError(string message) : base(message)
    {
    }
} 