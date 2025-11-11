using ShopHub.Application.Dtos.User;
using ShopHub.Domain.Entities;

namespace ShopHub.Application.Interfaces;

public interface IUserService
{
    Task<UserDto> GetUserByEmailAsync(string email);
    Task<UserDto> GetUserByUsernameAsync(string username);
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<UserDto> GetUserByIdAsync(int id);
    Task<UserDto> UpdateUserAsync(int id, UpdateUserDto user);
    Task<bool> DeleteUserAsync(int id);
}