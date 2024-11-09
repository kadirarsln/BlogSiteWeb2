using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Service.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogSite.Api.Controllers.PostsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController(IPostService _postService) : ControllerBase
    {
        [HttpGet("getall")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll()
        {
            var result = _postService.GetAll();
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] CreatePostRequest dto)
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var result = _postService.Add(dto, userId);
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var result = _postService.GetById(id);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var result = _postService.Remove(id);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] UpdatePostRequest update)
        {
            var result = _postService.Update(update);
            return Ok(result);
        }

        [HttpGet("getallbyauthorid")]
        public IActionResult GetAllByAyuthorId([FromRoute] string authorId)
        {
            var result = _postService.GetAllByAuthorId(authorId);
            return Ok(result);
        }
    }
}
