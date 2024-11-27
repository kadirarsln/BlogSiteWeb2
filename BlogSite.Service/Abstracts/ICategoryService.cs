using BlogSite.Models.Dtos.Categories.Requests;
using BlogSite.Models.Dtos.Categories.Responses;
using Core.Responses;

namespace BlogSite.Service.Abstracts;

public interface ICategoryService
{
    Task<ReturnModel<List<CategoryResponseDto>>> GetAllAsync();
    Task<ReturnModel<CategoryResponseDto>> GetByIdAsync(int id);
    Task<ReturnModel<NoData>> AddAsync(CreateCategoryRequest createdCategory);
    Task<ReturnModel<NoData>> UpdateAsync(UpdateCategoryRequest updatedCategory);
    Task<ReturnModel<NoData>> RemoveAsync(int id);
    //ReturnModel<List<CategoryWithPostsResponseDto>> GetCategoryWithPosts();
    //CategoryWithPostsResponseDto GetCategoryWithPostsById(int categoryId);
}
