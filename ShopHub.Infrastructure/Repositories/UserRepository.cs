using Microsoft.EntityFrameworkCore;
using ShopHub.Domain.Entities;
using ShopHub.Domain.Interfaces;
using ShopHub.Infrastructure.Data;

namespace ShopHub.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<User> GetUserByEmailAsync(string email)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u =>  u.Email == email);
        return user;
    }

    public async Task<User> GetUserByUsernameAsync(string Username)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == Username);
        return user;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        var users = await _dbContext.Users.ToListAsync();
        return users;
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        var  user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        return user;
    }

    public async Task<User> CreateUserAsync(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateUserAsync(int id, User user)
    {
        var existing = await _dbContext.Users.FindAsync(id);
        if (existing == null) return null;
        
        existing.Username = string.IsNullOrEmpty(user.Username) ? existing.Username : user.Username;
        existing.Email = string.IsNullOrEmpty(user.Email) ? existing.Email : user.Email;
        existing.PasswordHash = string.IsNullOrEmpty(user.PasswordHash) ? existing.PasswordHash : user.PasswordHash;
        existing.RoleId = user.RoleId == 0 ? existing.RoleId : user.RoleId;
        existing.UpdatedDate = DateTime.Now;
        await _dbContext.SaveChangesAsync();
        
        return existing;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await _dbContext.Users.FindAsync(id);
        if (user == null) return false;

        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}