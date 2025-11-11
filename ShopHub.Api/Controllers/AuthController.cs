using Microsoft.AspNetCore.Mvc;
using ShopHub.Application.Dtos.Authentication;
using ShopHub.Application.Dtos.User;
using ShopHub.Application.Services;

namespace ShopHub.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateUserDto dto)
    {
        var result = await _authService.CreateAsync(dto);

        if (result == null) return BadRequest(new { message = "Usuario o Email ya en uso." });
        
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var result = await _authService.LoginAsync(dto);

        if (result == null) return BadRequest(new { message = "Credenciales de ingreso incorrectas." });
        return Ok(result);
    }
}