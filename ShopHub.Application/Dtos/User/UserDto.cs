namespace ShopHub.Application.Dtos.User;

public class UserDto
{
    public int Id { get; set; }
    
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateOnly CreateDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    
    public int RoleId { get; set; }
}