using ShopHub.Domain.Entities;

namespace ShopHub.Domain.Interfaces;

public interface IProductRepository
{
    Task<Product> GetProductByIdAsync(int id);
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<IEnumerable<Product>?> GetProductByNameFilterAsync(string name);
    Task<IEnumerable<Product>> GetProductByCategoryIdAsync(int categoryId);
    Task<Product> CreateProductAsync(Product product);
}