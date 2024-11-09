using BlogSite.Models.Dtos.Categories.Requests;
using BlogSite.Models.Dtos.Categories.Responses;
using Core.Responses;

namespace BlogSite.Service.Abstracts;

public interface ICategoryService
{
    ReturnModel<List<CategoryResponseDto>> GetAll();
    ReturnModel<CategoryResponseDto> GetById(int id);

    ReturnModel<NoData> Add(CreateCategoryRequest createdCategory);
    ReturnModel<NoData> Update(UpdateCategoryRequest updatedCategory);
    ReturnModel<NoData> Remove(int id);
    //ReturnModel<List<CategoryWithPostsResponseDto>> GetCategoryWithPosts();
    //CategoryWithPostsResponseDto GetCategoryWithPostsById(int categoryId);
}
