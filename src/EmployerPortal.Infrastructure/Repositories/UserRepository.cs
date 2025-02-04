using System.Threading.Tasks;
using EmployerPortal.Domain.Entities;
using EmployerPortal.Domain.Interfaces;
using EmployerPortal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployerPortal.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext _context) : IUserRepository
{
    public async Task<User> GetByUsernameAsync(string username)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }
}