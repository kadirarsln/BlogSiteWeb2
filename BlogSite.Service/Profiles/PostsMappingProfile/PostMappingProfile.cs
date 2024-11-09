using AutoMapper;
using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Models.Dtos.Posts.Responses;
using BlogSite.Models.Entities;


namespace BlogSite.Service.Profiles.PostsMappingProfile;

public class PostMappingProfile : Profile
{
    public PostMappingProfile()
    {
        CreateMap<CreatePostRequest, Post>();
        CreateMap<UpdatePostRequest, Post>();
        CreateMap<Post, PostResponseDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(x => x.Category.Name))
        .ForMember(x => x.Username, opt => opt.MapFrom(X => X.Author.UserName));
        //CreateMap<List<Post>, List<PostResponseDto>>();
    }

}
