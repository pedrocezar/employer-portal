using EmployerPortal.Domain.Entities;

namespace EmployerPortal.Domain.Interfaces;

public interface IUserRepository
{
    Task<User> GetByUsernameAsync(string username);
    Task AddAsync(User user);
}