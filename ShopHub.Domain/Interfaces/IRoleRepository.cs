using ShopHub.Domain.Entities;

namespace ShopHub.Domain.Interfaces;

public interface IRoleRepository
{
    Task<IEnumerable<Role>> GetAllRolesAsync();
    Task<Role> GetRoleByIdAsync(int roleId);
}