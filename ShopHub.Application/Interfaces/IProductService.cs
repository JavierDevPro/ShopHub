using ShopHub.Application.Dtos.Product;

namespace ShopHub.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAll();
    Task<ProductDto> CreateProduct(CreateProductDto productDto);
}