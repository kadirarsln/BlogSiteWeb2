using BlogSite.Models.Dtos.Comments.Requests;
using FluentValidation;

public class UpdateCommentRequestValidator : AbstractValidator<UpdateCommentRequestDto>
{
    public UpdateCommentRequestValidator()
    {
        // Id alanı geçerli bir Guid olmalı
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Yorum ID boş olamaz")
            .Must(id => id != Guid.Empty).WithMessage("Geçerli bir Yorum ID giriniz.");

        // Text alanı boş olamaz ve en az 5 karakter olmalı
        RuleFor(x => x.Text)
            .NotEmpty().WithMessage("Yorum metni boş olamaz")
            .MinimumLength(5).WithMessage("Yorum metni en az 5 karakter olmalıdır.");
    }
}