using BlogSite.Models.Dtos.Users.Requests;
using BlogSite.Service.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Api.Controllers.AuthenticationsController;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationsController(IAuthenticationService _authenticationService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginRequestDto loginRequestDto)
    {
        var result = await _authenticationService.LoginAsync(loginRequestDto);
        return Ok(result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequestDto registerRequestDto)
    {
        var result = await _authenticationService.RegisterAsync(registerRequestDto);
        return Ok(result);
    }
}
