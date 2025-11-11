using Microsoft.AspNetCore.Mvc;
using ShopHub.Application.Services;

namespace ShopHub.Api.Controllers;

public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }
}