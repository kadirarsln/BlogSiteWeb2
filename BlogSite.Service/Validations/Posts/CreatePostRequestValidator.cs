
using BlogSite.Models.Dtos.Posts.Requests;
using FluentValidation;

namespace BlogSite.Service.Validations.Posts;

public class CreatePostRequestValidator : AbstractValidator<CreatePostRequest>
{
    public CreatePostRequestValidator()
    {
        // Title alanı boş olamaz ve en az 5 karakter olmalı
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Post Başlığı boş olamaz")
            .MinimumLength(5).WithMessage("Post Başlığı en az 5 karakter olmalıdır.");

        // Content alanı boş olamaz ve en az 20 karakter olmalı
        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Post İçeriği boş olamaz")
            .MinimumLength(20).WithMessage("Post İçeriği en az 20 karakter olmalıdır.");

        // CategoryId sıfır veya negatif bir değer olamaz
        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("Geçerli bir kategori ID'si giriniz.");
    }
}
