using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Api.Controllers.PostsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController(IPostService _postService) : ControllerBase
    {
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _postService.GetAll();
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] CreatePostRequest dto)
        {
            var result = _postService.Add(dto);
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
