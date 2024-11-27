using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Concretes;
using BlogSite.Models.Dtos.Comments.Requests;
using BlogSite.Models.Dtos.Comments.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;
using Core.Exceptions;
using Core.Responses;

namespace BlogSite.Service.Concretes
{
    public class CommentService(ICommentRepository _commentRepository, IMapper _mapper) : ICommentService
    {

        public Task<ReturnModel<List<CommentResponseDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ReturnModel<CommentResponseDto>> GetByIdAsync(Guid id)
        {
            Comment comment = await CheckByIdAsync(id);
            var response = _mapper.Map<CommentResponseDto>(comment);

            return new ReturnModel<CommentResponseDto>
            {
                Data = response,
                StatusCode = 200,
                Success = true,
            };
        }

        public async Task<ReturnModel<NoData>> AddAsync(CreateCommentRequestDto createdComment, string userId)
        {
            Comment comment = _mapper.Map<Comment>(createdComment);
            comment.Id = Guid.NewGuid();
            comment.UserId = userId;

            await _commentRepository.AddAsync(comment);
            return new ReturnModel<NoData>
            {
                Message = "Comment Added.",
                StatusCode = 200,
                Success = true,
            };
        }

        public async Task<ReturnModel<NoData>> UpdateAsync(UpdateCommentRequestDto updatedComment)
        {
            //Comment comment = await CheckByIdAsync(updatedComment.Id);
            //comment.Text = updatedComment.Text;
            //comment.
            throw new Exception();
        }

        public async Task<ReturnModel<NoData>> RemoveAsync(Guid id, string userId)
        {
            Comment comment = await CheckByIdAsync(id);
            comment.UserId = userId;

            await _commentRepository.RemoveAsync(comment);

            return new ReturnModel<NoData>
            {
                Message = "Comment Deleted.",
                StatusCode = 200,
                Success = true,
            };
        }

        public async Task<ReturnModel<List<CommentResponseDto>>> GetAllByUserIdAsync(string userId)
        {
            var comments = await _commentRepository.GetAllAsync(x => x.UserId == userId);
            var responses = _mapper.Map<List<CommentResponseDto>>(comments);

            return new ReturnModel<List<CommentResponseDto>>
            {
                Data = responses,
                Message = string.Empty,
                StatusCode = 200,
                Success = true,
            }; ;
        }

        public async Task<ReturnModel<List<CommentResponseDto>>> GetAllByPostIdAsync(Guid postId)
        {
            var comments = await _commentRepository.GetAllAsync(x => x.PostId == postId);
            var responses = _mapper.Map<List<CommentResponseDto>>(comments);

            return new ReturnModel<List<CommentResponseDto>>
            {
                Data = responses,
                Message = string.Empty,
                StatusCode = 200,
                Success = true,
            };
        }

        private async Task<Comment> CheckByIdAsync(Guid id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null)
            {
                throw new NotFoundException("Comment not found.");
            }
            return comment;
        }
    }
}
