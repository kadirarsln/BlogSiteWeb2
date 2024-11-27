
using BlogSite.Models.Dtos.Posts.Requests;
using FluentValidation;

namespace BlogSite.Service.Validations.Posts;

public class UpdatePostRequestValidator : AbstractValidator<UpdatePostRequest>
{
    public UpdatePostRequestValidator()
    {
        // Id alanı boş olmamalı ve geçerli bir Guid değeri olmalı
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Post ID boş olamaz")
            .Must(id => id != Guid.Empty).WithMessage("Geçerli bir Post ID giriniz.");

        // Title alanı boş olamaz ve en az 5 karakter olmalı
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Post Başlığı boş olamaz")
            .MinimumLength(5).WithMessage("Post Başlığı en az 5 karakter olmalıdır.");

        // Content alanı boş olamaz ve en az 20 karakter olmalı
        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Post İçeriği boş olamaz")
            .MinimumLength(20).WithMessage("Post İçeriği en az 20 karakter olmalıdır.");
    }
}