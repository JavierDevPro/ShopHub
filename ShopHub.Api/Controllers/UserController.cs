using Microsoft.AspNetCore.Mvc;
using ShopHub.Application.Interfaces;

namespace ShopHub.Api.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    //DNS & DPS
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllUsersAsync();
        return Ok(result);
    }
}