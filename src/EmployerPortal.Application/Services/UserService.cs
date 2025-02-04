using EmployerPortal.Application.Services.Interfaces;
using EmployerPortal.Domain.Errors;
using EmployerPortal.Domain.Interfaces;

namespace EmployerPortal.Application.Services;

public class UserService(IUserRepository _userRepository) : IUserService
{
    public async Task<string> WelcomeUserAsync(string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            throw new ArgumentException("Username cannot be empty", nameof(username));
        }

        var user = await _userRepository.GetByUsernameAsync(username);

        if (user == null)
            throw new NotFoundError($"User with username '{username}' was not found");

        return $"Hello, {user.Name}";
    }
}