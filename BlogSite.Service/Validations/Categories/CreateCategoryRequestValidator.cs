

using BlogSite.Models.Dtos.Categories.Requests;
using FluentValidation;

namespace BlogSite.Service.Validations.Categories;

public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
{
    public CreateCategoryRequestValidator()
    {
        // Name alanı boş olamaz ve en az 3 karakter olmalı
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kategori Adı boş olamaz")
            .MinimumLength(3).WithMessage("Kategori Adı en az 3 karakter olmalıdır.");
    }
}
