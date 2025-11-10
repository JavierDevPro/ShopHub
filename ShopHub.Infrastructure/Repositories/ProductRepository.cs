using ShopHub.Domain.Entities;
using ShopHub.Domain.Interfaces;
using ShopHub.Infrastructure.Data;

namespace ShopHub.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Task<Product> GetProductByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>?> GetProductByNameFilterAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetProductByCategoryIdAsync(int categoryId)
    {
        throw new NotImplementedException();
    }
}