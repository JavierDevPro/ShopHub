using ShopHub.Application.Dtos.Product;
using ShopHub.Application.Interfaces;
using ShopHub.Domain.Entities;
using ShopHub.Domain.Interfaces;

namespace ShopHub.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    private ProductDto MapDto(Product product)
    {
        return new ProductDto
        {
            Id = product.Id,

            // Propiedades específicas del producto
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,

            // Propiedad calculada: Precio con IVA
            PriceIVA = product.Price * (1 + 0.19),

            // Propiedades de auditoría (fechas)
            CreatedDate = product.CreatedDate,
            UpdatedDate = product.UpdatedDate,

            // Claves foráneas (FKs)
            CategoryId = product.CategoryId,
            UserId = product.UserId
        };
    }
    
    public async Task<IEnumerable<ProductDto>> GetAll()
    {
        var products = await _repository.GetAllProductsAsync();
        return (products != null) ? products.Select(MapDto) : null;
    }

    public async Task<ProductDto> CreateProduct(CreateProductDto productDto)
    {
        var maped = new Product
        {
            Name = productDto.Name,
            Description = productDto.Description,
            CategoryId = productDto.CategoryId,
            UserId = productDto.UserId,
            Price = productDto.Price,
            PriceIVA = productDto.Price * (1 + 0.19),
            CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now
        };
        var product = await _repository.CreateProductAsync(maped);
        return (product != null) ? MapDto(product) : null;
    }
}