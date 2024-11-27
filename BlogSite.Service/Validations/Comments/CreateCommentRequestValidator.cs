using BlogSite.Models.Dtos.Comments.Requests;
using FluentValidation;

namespace BlogSite.Service.Validations.Comments
{
    public class CreateCommentRequestValidator : AbstractValidator<CreateCommentRequestDto>
    {
        public CreateCommentRequestValidator()
        {
            // Text alanı boş olamaz ve en az 5 karakter olmalı
            RuleFor(x => x.Text)
                .NotEmpty().WithMessage("Yorum metni boş olamaz")
                .MinimumLength(5).WithMessage("Yorum metni en az 5 karakter olmalıdır.");

            // PostId geçerli bir Guid olmalı
            RuleFor(x => x.PostId)
                .NotEmpty().WithMessage("Post ID boş olamaz")
                .Must(id => id != Guid.Empty).WithMessage("Geçerli bir Post ID giriniz.");
        }
    }
}
