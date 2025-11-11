using System.Security.Cryptography;
using System.Text;
using ShopHub.Application.Dtos.User;
using ShopHub.Application.Interfaces;
using ShopHub.Domain.Entities;
using ShopHub.Domain.Interfaces;

namespace ShopHub.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    private UserDto MapDto(User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            RoleId = user.RoleId,
            CreateDate = user.CreateDate,
            UpdatedDate = user.UpdatedDate
        };
    }
    
    public Task<UserDto> GetUserByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> GetUserByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> GetUserByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> UpdateUserAsync(int id, UpdateUserDto user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUserAsync(int id)
    {
        throw new NotImplementedException();
    }
}