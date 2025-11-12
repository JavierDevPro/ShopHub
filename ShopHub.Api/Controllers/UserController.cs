using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllUsersAsync();
        return Ok(result);
    }
}