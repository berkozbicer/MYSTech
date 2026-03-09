using FluentValidation;
using MYSTech.DTO.DTOs.AboutDTOs;

namespace MYSTech.API.Validators
{
    public class CreateAboutValidator : AbstractValidator<CreateAboutDto>
    {
        public CreateAboutValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama boş olamaz.")
                .MaximumLength(2000).WithMessage("Açıklama en fazla 2000 karakter olabilir.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Görsel URL boş olamaz.")
                .MaximumLength(500).WithMessage("Görsel URL en fazla 500 karakter olabilir.");
        }
    }
}
