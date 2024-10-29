using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Categories.Requests;
using BlogSite.Models.Dtos.Categories.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;
using Core.Exceptions;
using Core.Responses;

namespace BlogSite.Service.Concretes;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }


    public ReturnModel<List<CategoryResponseDto>> GetAll()
    {
        List<Category> categories = _categoryRepository.GetAll();
        List<CategoryResponseDto> responses = _mapper.Map<List<CategoryResponseDto>>(categories);

        return new ReturnModel<List<CategoryResponseDto>>
        {
            Data = responses,
            Message = string.Empty,
            StatusCode = 200,
            Success = true,
        };
    }

    public ReturnModel<CategoryResponseDto> GetById(int id)
    {
        var category = _categoryRepository.GetById(id);
        if (category == null)
        {
            throw new NotFoundException("Category not found.");
        }
        var response = _mapper.Map<CategoryResponseDto>(category);
        return new ReturnModel<CategoryResponseDto>
        {
            Data = response,
            Success = true,
            Message = "Category is found",
            StatusCode = 200
        };
    }

    public ReturnModel<List<CategoryWithPostsResponseDto>> GetCategoryWithPosts()
    {
        var categories = _categoryRepository.GetCategoryWithPosts().ToList();
        var categoryDto = _mapper.Map<List<CategoryWithPostsResponseDto>>(categories);

        return new ReturnModel<List<CategoryWithPostsResponseDto>>
        {
            Success = true,
            Data = categoryDto,
            Message = "Category with posts are listed.",
            StatusCode = 200
        };
    }

    public CategoryWithPostsResponseDto GetCategoryWithPostsById(int categoryId)
    {
        var category = _categoryRepository.GetCategoryWithPostsById(categoryId);

        if (category == null)
        {
            throw new NotFoundException("Category not found.");
        }

        var categoryDto = _mapper.Map<CategoryWithPostsResponseDto>(category);
        return categoryDto;
    }

    public ReturnModel<CategoryResponseDto> Add(CreateCategoryRequest createdCategory)
    {
        if (string.IsNullOrEmpty(createdCategory.Name))
        {
            throw new ValidationException("Category name cannot be empty.");
        }

        Category category = _mapper.Map<Category>(createdCategory);
        _categoryRepository.Add(category);

        CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(category);
        return new ReturnModel<CategoryResponseDto>
        {
            Data = response,
            Message = "Category Added",
            StatusCode = 201,
            Success = true,
        };
    }


    public ReturnModel<CategoryResponseDto> Remove(int id)
    {
        Category category = _categoryRepository.GetById(id);
        if (category == null)
        {
            throw new NotFoundException("Category not found.");
        }
        Category deletedCategory = _categoryRepository.Remove(category);

        CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(deletedCategory);
        return new ReturnModel<CategoryResponseDto>
        {
            Data = response,
            Message = "Category Deleted",
            StatusCode = 200,
            Success = true,
        };
    }

    public ReturnModel<CategoryResponseDto> Update(UpdateCategoryRequest updateCategory)
    {
        throw new NotImplementedException();
    }
}
