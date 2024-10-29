using BlogSite.Models.Dtos.Comments.Requests;
using BlogSite.Models.Dtos.Comments.Responses;
using BlogSite.Service.Abstracts;
using Core.Exceptions;
using Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Api.Controllers.CommentsController;

[Route("api/[controller]")]
[ApiController]
public class CommentsController(ICommentService _commentService) : ControllerBase
{

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _commentService.GetAll();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public ActionResult<ReturnModel<CommentResponseDto?>> GetById([FromRoute] Guid id)
    {
        try
        {
            var result = _commentService.GetById(id);
            return Ok(result);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new ReturnModel<CommentResponseDto?>
            {
                Success = false,
                Message = ex.Message,
                Data = null,
                StatusCode = 404
            });
        }
    }

    [HttpPost("add")]
    public ActionResult<ReturnModel<CommentResponseDto?>> Add([FromBody] CreateCommentRequest request)
    {
        try
        {
            var result = _commentService.Add(request);
            return Ok(result);
        }
        catch (ValidationException ex)
        {
            return BadRequest(new ReturnModel<CommentResponseDto?>
            {
                Success = false,
                Message = ex.Message,
                Data = null,
                StatusCode = 400
            });
        }
    }


    [HttpDelete("delete")]
    public ActionResult<ReturnModel<CommentResponseDto>> Delete([FromRoute] Guid id)
    {
        try
        {
            var result = _commentService.Remove(id);
            return Ok(result);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new ReturnModel<CommentResponseDto>
            {
                Success = false,
                Message = ex.Message,
                Data = null,
                StatusCode = 404
            });
        }
    }
}
