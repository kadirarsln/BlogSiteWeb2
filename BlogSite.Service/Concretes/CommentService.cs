using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Comments.Requests;
using BlogSite.Models.Dtos.Comments.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;
using Core.Exceptions;
using Core.Responses;

namespace BlogSite.Service.Concretes
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public CommentService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public ReturnModel<List<CommentResponseDto>> GetAll()
        {
            List<Comment> comments = _commentRepository.GetAll();
            List<CommentResponseDto> responses = _mapper.Map<List<CommentResponseDto>>(comments);

            return new ReturnModel<List<CommentResponseDto>>
            {
                Data = responses,
                Message = string.Empty,
                StatusCode = 200,
                Success = true,
            };
        }

        public ReturnModel<CommentResponseDto> GetById(Guid id)
        {
            var comment = _commentRepository.GetById(id);
            if (comment == null)
            {
                throw new NotFoundException("Comment not found.");
            }
            var response = _mapper.Map<CommentResponseDto>(comment);
            return new ReturnModel<CommentResponseDto>
            {
                Data = response,
                Success = true,
                Message = "Comment is found",
                StatusCode = 200
            };
        }
        public ReturnModel<CommentResponseDto> Add(CreateCommentRequest createdComment)
        {
            if (string.IsNullOrEmpty(createdComment.Text))
            {
                throw new ValidationException("Comment text cannot be empty.");
            }

            Comment comment = _mapper.Map<Comment>(createdComment);
            comment.Id = Guid.NewGuid();
            _commentRepository.Add(comment);

            CommentResponseDto response = _mapper.Map<CommentResponseDto>(comment);

            return new ReturnModel<CommentResponseDto>
            {
                Data = response,
                Message = "Comment Added",
                StatusCode = 201,
                Success = true,
            };
        }

        public ReturnModel<CommentResponseDto> Remove(Guid id)
        {
            Comment comment = _commentRepository.GetById(id);
            if (comment == null)
            {
                throw new NotFoundException("Comment not found.");
            }
            Comment deletedComment = _commentRepository.Remove(comment);

            CommentResponseDto response = _mapper.Map<CommentResponseDto>(deletedComment);
            return new ReturnModel<CommentResponseDto>
            {
                Data = response,
                Message = "Comment Deleted",
                StatusCode = 200,
                Success = true,
            };
        }

        public ReturnModel<CommentResponseDto> Update(UpdateCommentRequest updateComment)
        {
            throw new NotImplementedException();
        }
    }
}
