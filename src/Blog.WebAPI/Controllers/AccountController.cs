using Blog.Application.DTOs.Account;
using Blog.Application.DTOs.Tokens;
using Blog.Application.Services.AuthServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAuthService _authService;
    public AccountController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> RegisterAsync(RegistrationDto user)
    {
        var result =  await this._authService.RegisterAsync(user);
        return Ok(result);
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> LogInAsync(LoginDto dto)
    {
        var result =  await this._authService.LogInAsync(dto);
        return Ok(result);
    }

    [HttpPost]
    [Route("logOut")]
    public async Task<IActionResult> LogOutAsync(string token)
    {
        await this._authService.LogOutAsync(token);
        return Ok();
    }

    [HttpPost]
    [Route("refreshToken")]
    public async Task<IActionResult> RefreshAsync(string refreshToken)
    {
        var refreshResult = await this._authService.RefreshAsync(refreshToken);
        return Ok(refreshResult);

    }

    [HttpPost]
    [Route("isRevoked")]
    public async Task<IActionResult> IsRevokedAsync(string token)
    {
        await this._authService.IsRevokedAsync(token);
        return Ok();
    }
}