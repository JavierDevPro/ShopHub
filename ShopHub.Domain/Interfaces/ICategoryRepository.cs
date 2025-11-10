using ShopHub.Domain.Entities;

namespace ShopHub.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<Category> GetCategoryByNameAsync(string categoryName);
    Task<Category> GetCategoryByIdAsync(int categoryId);
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    
    Task<IEnumerable<Category>>? FilterCategories(IEnumerable<string>? categories, string? categoryName);
}