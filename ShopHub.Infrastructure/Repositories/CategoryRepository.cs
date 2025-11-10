using ShopHub.Domain.Entities;
using ShopHub.Domain.Interfaces;
using ShopHub.Infrastructure.Data;

namespace ShopHub.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _dbContext;
    
    public CategoryRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Task<Category> GetCategoryByNameAsync(string categoryName)
    {
        throw new NotImplementedException();
    }

    public Task<Category> GetCategoryByIdAsync(int categoryId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Category>>? FilterCategories(IEnumerable<string>? categories, string? categoryName)
    {
        throw new NotImplementedException();
    }
}