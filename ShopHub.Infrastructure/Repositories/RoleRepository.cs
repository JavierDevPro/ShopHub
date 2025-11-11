using Microsoft.EntityFrameworkCore;
using ShopHub.Domain.Entities;
using ShopHub.Domain.Interfaces;
using ShopHub.Infrastructure.Data;

namespace ShopHub.Infrastructure.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly AppDbContext _dbContext;
    
    public RoleRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Role>> GetAllRolesAsync()
    {
        return await _dbContext.Roles.ToListAsync();
    }

    public async Task<Role> GetRoleByIdAsync(int roleId)
    {
        var role = await _dbContext.Roles.FirstOrDefaultAsync(r => r.Id == roleId);
        return role;
    }
}