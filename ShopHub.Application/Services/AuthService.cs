using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShopHub.Application.Dtos.Authentication;
using ShopHub.Application.Dtos.User;
using ShopHub.Application.Interfaces;
using ShopHub.Domain.Interfaces;

namespace ShopHub.Application.Services;

public class AuthService
{
    private readonly IConfiguration _configuration;
    private readonly IRoleService _roleService;
    private readonly IUserRepository _userRepository;

    public AuthService(IConfiguration configuration, RoleService roleService, IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _roleService = roleService;
        _configuration = configuration;
    }

    public async Task<AuthResponseDto?> CreateAsync(CreateUserDto createUserDto)
    {
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(createUserDto.Password);

        var createdUser = await _userRepository.GetUserByUsernameAsync(createUserDto.Username); 

        return new AuthResponseDto
        {
            UserNameOrEmail = (createdUser.Email == null) ? createdUser.Email : createdUser.Username,
            Role = await GetRoleNameAsync(createdUser.RoleId),
            ExpiresAt = DateTime.UtcNow.AddMinutes(15)
        };
    }

    public async Task<AuthResponseDto?> LoginAsync(LoginDto dto)
    {
        // Buscar usuario por username
        var user = await _userRepository.GetUserByUsernameAsync(dto.UserNameOrEmail);
        
        if (user == null) return null;

        // Verificar contraseña con BCrypt
        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);
        
        if (!isPasswordValid) return null;

        var userMap = new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            RoleId = user.RoleId,
            UpdatedDate = user.UpdatedDate,
            CreateDate = user.CreateDate
        };
        
        // Generar token JWT
        var token = await GenerateJwtToken(userMap);

        return new AuthResponseDto
        {
            Token = token,
            UserNameOrEmail = user.Username,
            Role = user.Role.Name,
            ExpiresAt = DateTime.UtcNow.AddMinutes(15)
        };
    }

    public async Task<string> GetRoleNameAsync(int roleId)
    {
        var role = await _roleService.GetRoleByIdAsync(roleId);
        return role.Name;
    }
    
    // GENERAR TOKEN JWT
    private async Task<string?> GenerateJwtToken(UserDto user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role, await GetRoleNameAsync(user.RoleId)), // "Admin" o "User"
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)
        );
        
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}