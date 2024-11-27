using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Service.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogSite.Api.Controllers.PostsController;

[Route("api/[controller]")]
[ApiController]
public class PostsController(IPostService _postService) : ControllerBase
{
    [HttpGet("getall")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _postService.GetAllAsync();
        return Ok(result);
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddAsync([FromBody] CreatePostRequest dto)
    {
        var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
        var result = await _postService.AddAsync(dto, userId);
        return Ok(result);
    }

    [HttpGet("getbyid")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
    {
        var result = await _postService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _postService.RemoveAsync(id);
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdatePostRequest update)
    {
        var result = await _postService.UpdateAsync(update);
        return Ok(result);
    }

    [HttpGet("getallbyauthorid")]
    public async Task<IActionResult> GetAllByAyuthorIdAsync([FromRoute] string authorId)
    {
        var result = await _postService.GetAllByAuthorIdAsync(authorId);
        return Ok(result);
    }
}
