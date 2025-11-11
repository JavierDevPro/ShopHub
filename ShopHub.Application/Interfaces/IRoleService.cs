using ShopHub.Application.Dtos.Role;

namespace ShopHub.Application.Interfaces;

public interface IRoleService
{
    Task<IEnumerable<RoleDto>> GetAllRolesAsync();
    
    Task<RoleDto> GetRoleByIdAsync(int roleId);
}