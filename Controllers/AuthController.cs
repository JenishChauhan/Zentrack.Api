namespace Zentrack.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Zentrack.Api.Services;
using Zentrack.Api.Models;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    public class UserDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserDto request)
    {
        var result = await _authService.RegisterAsync(request.Username, request.Password);
        
        if (!result.Success)
        {
            return BadRequest(ApiResponse<object>.BadRequest(result.Message));
        }

        return Ok(ApiResponse<object>.Created(null, result.Message));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserDto request)
    {
        var result = await _authService.LoginAsync(request.Username, request.Password);

        if (!result.Success)
        {
            return Unauthorized(ApiResponse<object>.Unauthorized(result.Message));
        }

        return Ok(ApiResponse<object>.Ok(new { token = result.Token }, result.Message));
    }
}
