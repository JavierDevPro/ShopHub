namespace ShopHub.Application.Dtos.Authentication;

public class AuthResponseDto
{
    public string Token { get; set; } = string.Empty;
    public string UserNameOrEmail { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; }
}