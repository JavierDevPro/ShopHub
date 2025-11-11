using ShopHub.Application.Dtos.Role;
using ShopHub.Application.Interfaces;
using ShopHub.Domain.Entities;
using ShopHub.Domain.Interfaces;

namespace ShopHub.Application.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;
    
    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    private RoleDto MapDto(Role role)
    {
        return new RoleDto
        {
            Id = role.Id,
            Name = role.Name,
            Description = role.Description
        };
    }
    
    public Task<IEnumerable<RoleDto>> GetAllRolesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<RoleDto> GetRoleByIdAsync(int roleId)
    {
        var role = await _roleRepository.GetRoleByIdAsync(roleId);
        return MapDto(role);
    }
}