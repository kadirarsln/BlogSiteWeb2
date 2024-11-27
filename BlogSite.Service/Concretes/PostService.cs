using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Models.Dtos.Posts.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;
using BlogSite.Service.Rules;
using Core.Responses;

namespace BlogSite.Service.Concretes;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    private readonly PostBusinessRules _businessRules;
    public PostService(IPostRepository postRepository, IMapper mapper, PostBusinessRules businessRules)
    {
        _postRepository = postRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }
    public async Task<ReturnModel<List<PostResponseDto>>> GetAllAsync()
    {
        List<Post> posts = await _postRepository.GetAllAsync();
        List<PostResponseDto> responses = _mapper.Map<List<PostResponseDto>>(posts);

        return new ReturnModel<List<PostResponseDto>>
        {
            Data = responses,
            Message = string.Empty,
            StatusCode = 200,
            Success = true,
        };

    }

    public async Task<ReturnModel<PostResponseDto>> GetByIdAsync(Guid id)
    {
        var post = await _postRepository.GetByIdAsync(id);
        _businessRules.PostIsNullCheck(post);

        var response = _mapper.Map<PostResponseDto>(post);

        return new ReturnModel<PostResponseDto>
        {
            Data = response,
            Message = "Id is found",
            StatusCode = 200,
            Success = true,
        };
    }

    public async Task<ReturnModel<PostResponseDto>> AddAsync(CreatePostRequest create, string userId)
    {
        Post createdPost = _mapper.Map<Post>(create);
        createdPost.Id = Guid.NewGuid();
        createdPost.AuthorId = userId;

        await _postRepository.AddAsync(createdPost);

        PostResponseDto response = _mapper.Map<PostResponseDto>(createdPost);
        return new ReturnModel<PostResponseDto>
        {
            Data = response,
            Message = "Post Added",
            StatusCode = 201,
            Success = true,
        };
    }

    public async Task<ReturnModel<PostResponseDto>> RemoveAsync(Guid id)
    {
        Post post = await _postRepository.GetByIdAsync(id);
        _businessRules.PostIsNullCheck(post);

        Post deletedPost = await _postRepository.RemoveAsync(post);

        PostResponseDto response = _mapper.Map<PostResponseDto>(deletedPost);
        return new ReturnModel<PostResponseDto>
        {
            Data = response,
            Message = "Post Deleted",
            StatusCode = 200,
            Success = true,
        };
    }



    public async Task<ReturnModel<PostResponseDto>> UpdateAsync(UpdatePostRequest updatePost)
    {
        Post post = await _postRepository.GetByIdAsync(updatePost.Id);
        Post update = new Post
        {
            CategoryId = post.CategoryId,
            Content = updatePost.Content,
            Title = updatePost.Title,
            AuthorId = post.AuthorId,
            CreatedDate = post.CreatedDate,
        };
        Post updatedPost = await _postRepository.UpdateAsync(update);
        PostResponseDto dto = _mapper.Map<PostResponseDto>(updatedPost);
        return new ReturnModel<PostResponseDto>
        {
            Data = dto,
            Message = "Post güncellendi",
            StatusCode = 200,
            Success = true
        };


    }



    public async Task<ReturnModel<List<PostResponseDto>>> GetAllByAuthorIdAsync(string id)
    {
        var posts = await _postRepository.GetAllAsync(x => x.AuthorId == id);
        var response = _mapper.Map<List<PostResponseDto>>(posts);

        return new ReturnModel<List<PostResponseDto>>
        {
            Data = response,
            StatusCode = 200,
            Success = true
        };
    }

    public async Task<ReturnModel<List<PostResponseDto>>> GetAllByCategoryIdAsync(int id)
    {
        throw new NotImplementedException();
    }



    //public Post Add(CreatePostRequest create)
    //{
    //    Post post = _mapper.Map<Post>(create);      //Map içine yazdığımız şey dönüştürmeye çalıştığımız. Create -> Post
    //    Post createdPost = _postRepository.Add(post);

    //    return createdPost;
    //}

    //public Post Delete(Guid id)
    //{
    //    throw new NotImplementedException();
    //}

    //public List<PostResponseDto> GetAll()
    //{
    //    throw new NotImplementedException();
    //}

    //public PostResponseDto GetById(Guid id)
    //{
    //    throw new NotImplementedException();
    //}

    //public Post Update(UpdatePostRequest update)
    //{
    //    throw new NotImplementedException();
    //}
}
