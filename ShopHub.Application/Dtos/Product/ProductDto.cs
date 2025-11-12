namespace ShopHub.Application.Dtos.Product;

public class ProductDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public double PriceIVA { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    
    public int CategoryId { get; set; }
    
    public int UserId { get; set; }
}