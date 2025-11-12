using Microsoft.EntityFrameworkCore;
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
    
    public async Task<Product> GetProductByIdAsync(int id)
    {
        var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        return product;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _dbContext.Products.ToListAsync();
    }

    public Task<IEnumerable<Product>?> GetProductByNameFilterAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetProductByCategoryIdAsync(int categoryId)
    {
        throw new NotImplementedException();
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }
}