using BlogSite.Models.Dtos.Categories.Requests;
using BlogSite.Models.Dtos.Comments.Requests;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;
using Core.Tokens.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace BlogSite.Api.Controllers.CommentsController;

[Route("api/[controller]")]
[ApiController]
public class CommentsController(ICommentService _commentService, DecoderService decoderService) : ControllerBase
{

    [HttpGet("getall")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _commentService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("getbyid")]
    public async Task<IActionResult> GetByIdAsync([FromQuery] Guid id)
    {
        var result = await _commentService.GetByIdAsync(id);
        return Ok(result);

    }

    [HttpGet("getallbyuserid")]
    public async Task<IActionResult> GetAllByUserIdAsync(string userId)
    {
        var result = await _commentService.GetAllByUserIdAsync(userId);
        return Ok(result);
    }

    [HttpGet("owncomment")]
    public async Task<IActionResult> OwnComments()
    {
        var userId = decoderService.GetUserId();
        var result = await _commentService.GetAllByUserIdAsync(userId);
        return Ok(result);
    }

    [HttpGet("getallbypostid")]
    public async Task<IActionResult> GetAllByPostIdAsync(Guid postId)
    {
        var result = await _commentService.GetAllByPostIdAsync(postId);
        return Ok(result);
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateCommentRequestDto dto)
    {
        var userId = decoderService.GetUserId();
        var result = await _commentService.AddAsync(dto, userId);
        return Ok(result);
    }

    [HttpPost("update")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateCommentRequestDto dto)
    {
        var result = await _commentService.UpdateAsync(dto);
        return Ok(result);
    }


    [HttpDelete("delete")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync([FromQuery] Guid id)
    {
        var userId = decoderService.GetUserId();
        var result = await _commentService.RemoveAsync(id, userId);
        return Ok(result);
    }

}
