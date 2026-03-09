using FluentValidation;
using MYSTech.DTO.DTOs.SocialMediaDTOs;

namespace MYSTech.API.Validators
{
    public class CreateSocialMediaValidator : AbstractValidator<CreateSocialMediaDto>
    {
        public CreateSocialMediaValidator()
        {
            RuleFor(x => x.Icon)
                .NotEmpty().WithMessage("İkon boş olamaz.")
                .MaximumLength(200).WithMessage("İkon en fazla 200 karakter olabilir.");

            RuleFor(x => x.Url)
                .NotEmpty().WithMessage("URL boş olamaz.")
                .MaximumLength(500).WithMessage("URL en fazla 500 karakter olabilir.")
                .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _)).WithMessage("Geçerli bir URL giriniz.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık boş olamaz.")
                .MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olabilir.");
        }
    }
}
