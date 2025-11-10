namespace ShopHub.Domain.Entities;

public class User
{
    public int Id { get; set; }
    
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateOnly CreateDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    
    public int RoleId { get; set; }
    public Role Role { get; set; }
    
    public IEnumerable<Product> Products{ get; set; }
}