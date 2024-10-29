using BlogSite.Models.Dtos.Users.Requests;
using BlogSite.Service.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Api.Controllers.UsersController;

[Route("api/[controller]")]
[ApiController]
public class UsersController1(IUserService1 _userService1) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
    {
        var result = await _userService1.RegisterAsync(dto);
        return Ok(result);
    }

    [HttpGet("getbyemail")]
    public async Task<IActionResult> GetByEmail([FromQuery] string email)
    {
        var result = await _userService1.GetByEmailAsync(email);
        return Ok(result);
    }
}

