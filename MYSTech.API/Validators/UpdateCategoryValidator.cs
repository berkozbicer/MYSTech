using FluentValidation;
using MYSTech.DTO.DTOs.CategoryDTOs;

namespace MYSTech.API.Validators
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Geçerli bir ID giriniz.");

            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Kategori adı boş olamaz.")
                .MaximumLength(200).WithMessage("Kategori adı en fazla 200 karakter olabilir.");

            RuleFor(x => x.Slug)
                .NotEmpty().WithMessage("Slug boş olamaz.")
                .MaximumLength(200).WithMessage("Slug en fazla 200 karakter olabilir.")
                .Matches("^[a-z0-9-]+$").WithMessage("Slug sadece küçük harf, rakam ve tire içerebilir.");

            RuleFor(x => x.MetaTitle)
                .NotEmpty().WithMessage("Meta başlık boş olamaz.")
                .MaximumLength(200).WithMessage("Meta başlık en fazla 200 karakter olabilir.");

            RuleFor(x => x.MetaDescription)
                .NotEmpty().WithMessage("Meta açıklama boş olamaz.")
                .MaximumLength(500).WithMessage("Meta açıklama en fazla 500 karakter olabilir.");
        }
    }
}
