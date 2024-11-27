using BlogSite.Models.Dtos.Comments.Requests;
using BlogSite.Models.Dtos.Comments.Responses;
using Core.Responses;

namespace BlogSite.Service.Abstracts;

public interface ICommentService
{
    Task<ReturnModel<List<CommentResponseDto>>> GetAllAsync();
    Task<ReturnModel<CommentResponseDto>> GetByIdAsync(Guid id);
    Task<ReturnModel<NoData>> AddAsync(CreateCommentRequestDto createdComment, string userId);
    Task<ReturnModel<NoData>> UpdateAsync(UpdateCommentRequestDto updatedComment);
    Task<ReturnModel<NoData>> RemoveAsync(Guid id, string userId);

    Task<ReturnModel<List<CommentResponseDto>>> GetAllByUserIdAsync(string userId);
    Task<ReturnModel<List<CommentResponseDto>>> GetAllByPostIdAsync(Guid postId);
}
