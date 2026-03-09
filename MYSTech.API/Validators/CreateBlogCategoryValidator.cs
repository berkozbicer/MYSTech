using FluentValidation;
using MYSTech.DTO.DTOs.BlogCategoryDTOs;

namespace MYSTech.API.Validators
{
    public class CreateBlogCategoryValidator : AbstractValidator<CreateBlogCategoryDto>
    {
        public CreateBlogCategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Kategori adı boş olamaz.")
                .MaximumLength(200).WithMessage("Kategori adı en fazla 200 karakter olabilir.");

            RuleFor(x => x.Slug)
                .NotEmpty().WithMessage("Slug boş olamaz.")
                .MaximumLength(200).WithMessage("Slug en fazla 200 karakter olabilir.")
                .Matches("^[a-z0-9-]+$").WithMessage("Slug sadece küçük harf, rakam ve tire içerebilir.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama boş olamaz.")
                .MaximumLength(1000).WithMessage("Açıklama en fazla 1000 karakter olabilir.");

            RuleFor(x => x.IconUrl)
                .NotEmpty().WithMessage("İkon URL boş olamaz.")
                .MaximumLength(500).WithMessage("İkon URL en fazla 500 karakter olabilir.");

            RuleFor(x => x.DisplayOrder)
                .GreaterThanOrEqualTo(0).WithMessage("Sıra 0 veya daha büyük olmalıdır.");
        }
    }

}
