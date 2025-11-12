using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopHub.Application.Dtos.Product;
using ShopHub.Application.Interfaces;

namespace ShopHub.Api.Controllers;

[ApiController]
[Route("api/user")]
[Authorize]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAll();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto dto)
    {
        var result = await _service.CreateProduct(dto);
        return (result != null) ? Ok(result) : BadRequest(new { message = "ERROR: Hay algun error" });
    }
}