using AutoMapper;
using BlogSite.Models.Dtos.Comments.Requests;
using BlogSite.Models.Dtos.Comments.Responses;
using BlogSite.Models.Entities;

namespace BlogSite.Service.Profiles.CommentsMappingProfile
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<CreateCommentRequestDto, Comment>();
            CreateMap<UpdateCommentRequestDto, Comment>();
            CreateMap<Comment, CommentResponseDto>()
                .ForMember(dest => dest.PostTitle, opt => opt.MapFrom(x => x.Post.Title))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(x => x.User.UserName));
        }
    }
}
