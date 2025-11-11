namespace ShopHub.Application.Dtos.Authentication;

public class RegisterDto
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int RoleId { get; set; }
    public string Password { get; set; } = string.Empty;
}