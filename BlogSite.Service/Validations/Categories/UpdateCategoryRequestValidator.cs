

using BlogSite.Models.Dtos.Categories.Requests;
using FluentValidation;

namespace BlogSite.Service.Validations.Categories;

public class UpdateCategoryRequestValidator : AbstractValidator<UpdateCategoryRequest>
{
    public UpdateCategoryRequestValidator()
    {
        // Id alanı geçerli bir değer olmalı (0 veya negatif olamaz)
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Geçerli bir Kategori ID'si giriniz.");

        // Name alanı boş olamaz ve en az 3 karakter olmalı
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Kategori Adı boş olamaz")
            .MinimumLength(3).WithMessage("Kategori Adı en az 3 karakter olmalıdır.");
    }
}