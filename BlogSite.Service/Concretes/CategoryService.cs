using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Categories.Requests;
using BlogSite.Models.Dtos.Categories.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;
using Core.Exceptions;
using Core.Responses;

namespace BlogSite.Service.Concretes;

public class CategoryService(IMapper _mapper, ICategoryRepository _categoryRepository) : ICategoryService
{
    public async Task<ReturnModel<List<CategoryResponseDto>>> GetAllAsync()
    {
        List<Category> categories = await _categoryRepository.GetAllAsync();
        List<CategoryResponseDto> responses = _mapper.Map<List<CategoryResponseDto>>(categories);

        return new ReturnModel<List<CategoryResponseDto>>
        {
            Data = responses,
            Message = string.Empty,
            StatusCode = 200,
            Success = true,
        };
    }

    public async Task<ReturnModel<CategoryResponseDto>> GetByIdAsync(int id)
    {
        var category = await CheckByIdAsync(id);
        var response = _mapper.Map<CategoryResponseDto>(category);

        return new ReturnModel<CategoryResponseDto>
        {
            Data = response,
            Success = true,
            Message = "Category is found",
            StatusCode = 200
        };
    }

    //public ReturnModel<List<CategoryWithPostsResponseDto>> GetCategoryWithPosts()
    //{
    //    var categories = _categoryRepository.GetCategoryWithPosts().ToList();
    //    var categoryDto = _mapper.Map<List<CategoryWithPostsResponseDto>>(categories);

    //    return new ReturnModel<List<CategoryWithPostsResponseDto>>
    //    {
    //        Success = true,
    //        Data = categoryDto,
    //        Message = "Category with posts are listed.",
    //        StatusCode = 200
    //    };
    //}

    //public CategoryWithPostsResponseDto GetCategoryWithPostsById(int categoryId)
    //{
    //    var category = _categoryRepository.GetCategoryWithPostsById(categoryId);

    //    if (category == null)
    //    {
    //        throw new NotFoundException("Category not found.");
    //    }

    //    var categoryDto = _mapper.Map<CategoryWithPostsResponseDto>(category);
    //    return categoryDto;
    //}

    public async Task<ReturnModel<NoData>> AddAsync(CreateCategoryRequest createdCategory)
    {
        if (string.IsNullOrEmpty(createdCategory.Name))
        {
            throw new ValidationException("Category name cannot be empty.");
        }
        Category category = _mapper.Map<Category>(createdCategory);
        await _categoryRepository.AddAsync(category);

        return new ReturnModel<NoData>
        {
            Message = "Category Added",
            StatusCode = 201,
            Success = true,
        };
    }


    public async Task<ReturnModel<NoData>> RemoveAsync(int id)
    {
        Category category = await CheckByIdAsync(id);
        await _categoryRepository.RemoveAsync(category);

        return new ReturnModel<NoData>
        {
            Message = "Category Deleted",
            StatusCode = 200,
            Success = true,
        };
    }

    public async Task<ReturnModel<NoData>> UpdateAsync(UpdateCategoryRequest updatedCategory)
    {
        Category category = await CheckByIdAsync(updatedCategory.Id);
        category.Name=updatedCategory.Name;
        
        await _categoryRepository.UpdateAsync(category);
        return new ReturnModel<NoData>
        { Message = "Category Updated",
        StatusCode=201,
        Success = true,
        };
    }

    private async Task<Category> CheckByIdAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category == null)
        {
            throw new NotFoundException("Category not found.");
        }
        return category;
    }
}
