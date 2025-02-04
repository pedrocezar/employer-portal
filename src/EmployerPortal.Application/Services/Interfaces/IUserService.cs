namespace EmployerPortal.Application.Services.Interfaces;

public interface IUserService
{
    Task<string> WelcomeUserAsync(string username);
}