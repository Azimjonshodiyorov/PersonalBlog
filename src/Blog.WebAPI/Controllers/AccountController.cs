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
    public async Task<TokenResponse> RegisterAsync(RegistrationDto user) =>
        await this._authService.RegisterAsync(user);

    [HttpPut]
    [Route("login")]
    public async Task<TokenResponse> LogInAsync(LoginDto dto) =>
        await this._authService.LogInAsync(dto);

    [HttpPost]
    [Route("logOut")]
    public async Task<IActionResult> LogOutAsync(string token)
    {
        await this._authService.LogOutAsync(token);
        return Ok();
    }

    [HttpPut]
    [Route("refreshToken")]
    public async Task<TokenResponse> RefreshAsync(string refreshToken) =>
        await this._authService.RefreshAsync(refreshToken);

    [HttpPost]
    [Route("isRevoked")]
    public async Task<IActionResult> IsRevokedAsync(string token)
    {
        await this._authService.IsRevokedAsync(token);
        return Ok();
    }
}