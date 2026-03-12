using FluentValidation;
using MYSTech.DTO.DTOs.AboutDTOs;

namespace MYSTech.API.Validators
{
    public class CreateAboutValidator : AbstractValidator<CreateAboutDto>
    {
        public CreateAboutValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık boş olamaz.")
                .MaximumLength(300).WithMessage("Başlık en fazla 300 karakter olabilir.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("İçerik boş olamaz.")
                .MaximumLength(2000).WithMessage("İçerik en fazla 2000 karakter olabilir.");

            RuleFor(x => x.ImageUrl)
                .MaximumLength(500).WithMessage("Görsel URL en fazla 500 karakter olabilir.")
                .When(x => x.ImageUrl != null);
        }
    }
}
