namespace EmployerPortal.Domain.Errors;

public class ValidationError : DomainError
{
    public ValidationError(string message) : base(message)
    {
    }

    public ValidationError(string message, IDictionary<string, string[]> errors) : base(message)
    {
        Errors = errors;
    }

    public IDictionary<string, string[]> Errors { get; }
} 