using BlogSite.Models.Dtos.Categories.Requests;
using BlogSite.Service.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Api.Controllers.CategoriesController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService _categoryService) : ControllerBase
    {
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _categoryService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] int id)
        {
            var result = await _categoryService.GetByIdAsync(id);
            return Ok(result);

        }

        [HttpPost("add")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAsync([FromBody] CreateCategoryRequest dto)
        {
            var result = await _categoryService.AddAsync(dto);
            return Ok(result);
        }

        [HttpPost("update")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCategoryRequest dto)
        {
            var result = await _categoryService.UpdateAsync(dto);
            return Ok(result);
        }


        [HttpDelete("delete")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync([FromQuery] int id)
        {

            var result = await _categoryService.RemoveAsync(id);
            return Ok(result);
        }

        //[HttpGet("getcategorywithposts")]
        //public ActionResult<ReturnModel<List<CategoryWithPostsResponseDto>>> GetCategoryWithPosts()
        //{
        //    var result = _categoryService.GetCategoryWithPosts();
        //    return Ok(result);
        //}


        //[HttpGet("{categoryId}/posts")]
        //public async Task<IActionResult> GetDoctorWithAppointmentsById(int categoryId)
        //{
        //    try
        //    {
        //        var result = _categoryService.GetCategoryWithPostsById(categoryId);
        //        return Ok(result);
        //    }
        //    catch (NotFoundException ex)
        //    {
        //        return NotFound(new { message = "Category not Found" });
        //    }
        //}
    }
}
