using BlogSite.Models.Dtos.Categories.Requests;
using BlogSite.Models.Dtos.Categories.Responses;
using Core.Responses;

namespace BlogSite.Service.Abstracts;

public interface ICategoryService
{
    ReturnModel<List<CategoryResponseDto>> GetAll();
    ReturnModel<CategoryResponseDto> GetById(int id);

    ReturnModel<CategoryResponseDto> Add(CreateCategoryRequest createdCategory);
    ReturnModel<CategoryResponseDto> Update(UpdateCategoryRequest updatedCategory);
    ReturnModel<CategoryResponseDto> Remove(int id);
    ReturnModel<List<CategoryWithPostsResponseDto>> GetCategoryWithPosts();
    CategoryWithPostsResponseDto GetCategoryWithPostsById(int categoryId);
}
