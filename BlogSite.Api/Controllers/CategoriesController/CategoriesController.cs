using BlogSite.Models.Dtos.Categories.Requests;
using BlogSite.Models.Dtos.Categories.Responses;
using BlogSite.Service.Abstracts;
using Core.Exceptions;
using Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Api.Controllers.CategoriesController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService _categoryService) : ControllerBase
    {
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<ReturnModel<CategoryResponseDto?>> GetById([FromRoute] int id)
        {
            try
            {
                var result = _categoryService.GetById(id);
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ReturnModel<CategoryResponseDto?>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null,
                    StatusCode = 404
                });
            }
        }

        [HttpPost("add")]
        public ActionResult<ReturnModel<CategoryResponseDto?>> Add([FromBody] CreateCategoryRequest request)
        {
            try
            {
                var result = _categoryService.Add(request);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new ReturnModel<CategoryResponseDto?>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null,
                    StatusCode = 400
                });
            }
        }


        [HttpDelete("delete")]
        public ActionResult<ReturnModel<CategoryResponseDto>> Delete([FromRoute] int id)
        {
            try
            {
                var result = _categoryService.Remove(id);
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ReturnModel<CategoryResponseDto>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null,
                    StatusCode = 404
                });
            }
        }

        [HttpGet("getcategorywithposts")]
        public ActionResult<ReturnModel<List<CategoryWithPostsResponseDto>>> GetCategoryWithPosts()
        {
            var result = _categoryService.GetCategoryWithPosts();
            return Ok(result);
        }


        [HttpGet("{categoryId}/posts")]
        public async Task<IActionResult> GetDoctorWithAppointmentsById(int categoryId)
        {
            try
            {
                var result = _categoryService.GetCategoryWithPostsById(categoryId);
                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = "Category not Found" });
            }
        }
    }
}
