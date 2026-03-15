using FluentValidation;
using MYSTech.DTO.DTOs.BannerDTOs;

namespace MYSTech.API.Validators
{
    public class UpdateBannerValidator : AbstractValidator<UpdateBannerDto>
    {
        public UpdateBannerValidator()
        {
            RuleFor(x => x.BannerId)
                .GreaterThan(0).WithMessage("Geçerli bir ID giriniz.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık boş olamaz.")
                .MaximumLength(200).WithMessage("Başlık en fazla 200 karakter olabilir.");

            RuleFor(x => x.SubTitle)
                .MaximumLength(400).WithMessage("Alt başlık en fazla 400 karakter olabilir.")
                .When(x => !string.IsNullOrEmpty(x.SubTitle));

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Görsel URL boş olamaz.")
                .MaximumLength(500).WithMessage("Görsel URL en fazla 500 karakter olabilir.");

            RuleFor(x => x.MobileImageUrl)
                .MaximumLength(500).WithMessage("Mobil görsel URL en fazla 500 karakter olabilir.")
                .When(x => !string.IsNullOrEmpty(x.MobileImageUrl));

            RuleFor(x => x.ButtonText)
                .MaximumLength(100).WithMessage("Buton metni en fazla 100 karakter olabilir.")
                .When(x => !string.IsNullOrEmpty(x.ButtonText));

            RuleFor(x => x.ButtonLink)
                .MaximumLength(500).WithMessage("Buton linki en fazla 500 karakter olabilir.")
                .When(x => !string.IsNullOrEmpty(x.ButtonLink));

            RuleFor(x => x.Order)
                .GreaterThanOrEqualTo(0).WithMessage("Sıra 0 veya daha büyük olmalıdır.");
        }
    }
}
