using FluentValidation;
using MYSTech.DTO.DTOs.BlogDTOs;

namespace MYSTech.API.Validators
{
    public class UpdateBlogValidator : AbstractValidator<UpdateBlogDto>
    {
        public UpdateBlogValidator()
        {
            RuleFor(x => x.BlogId)
                .GreaterThan(0).WithMessage("Geçerli bir ID giriniz.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık boş olamaz.")
                .MaximumLength(300).WithMessage("Başlık en fazla 300 karakter olabilir.");

            RuleFor(x => x.Slug)
                .NotEmpty().WithMessage("Slug boş olamaz.")
                .MaximumLength(300).WithMessage("Slug en fazla 300 karakter olabilir.")
                .Matches("^[a-z0-9-]+$").WithMessage("Slug sadece küçük harf, rakam ve tire içerebilir.");

            RuleFor(x => x.ShortDescription)
                .NotEmpty().WithMessage("Kısa açıklama boş olamaz.")
                .MaximumLength(500).WithMessage("Kısa açıklama en fazla 500 karakter olabilir.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("İçerik boş olamaz.");

            RuleFor(x => x.BlogCategoryId)
                .GreaterThan(0).WithMessage("Geçerli bir kategori seçiniz.");
        }
    }
}
