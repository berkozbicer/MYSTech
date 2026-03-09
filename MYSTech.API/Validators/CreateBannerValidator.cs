using FluentValidation;
using MYSTech.DTO.DTOs.BannerDTOs;

namespace MYSTech.API.Validators
{
    public class CreateBannerValidator : AbstractValidator<CreateBannerDto>
    {
        public CreateBannerValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık boş olamaz.")
                .MaximumLength(200).WithMessage("Başlık en fazla 200 karakter olabilir.");

            RuleFor(x => x.SubTitle)
                .NotEmpty().WithMessage("Alt başlık boş olamaz.")
                .MaximumLength(400).WithMessage("Alt başlık en fazla 400 karakter olabilir.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Görsel URL boş olamaz.")
                .MaximumLength(500).WithMessage("Görsel URL en fazla 500 karakter olabilir.");

            RuleFor(x => x.MobileImageUrl)
                .NotEmpty().WithMessage("Mobil görsel URL boş olamaz.")
                .MaximumLength(500).WithMessage("Mobil görsel URL en fazla 500 karakter olabilir.");

            RuleFor(x => x.ButtonText)
                .NotEmpty().WithMessage("Buton metni boş olamaz.")
                .MaximumLength(100).WithMessage("Buton metni en fazla 100 karakter olabilir.");

            RuleFor(x => x.ButtonLink)
                .NotEmpty().WithMessage("Buton linki boş olamaz.")
                .MaximumLength(500).WithMessage("Buton linki en fazla 500 karakter olabilir.");

            RuleFor(x => x.Order)
                .GreaterThanOrEqualTo(0).WithMessage("Sıra 0 veya daha büyük olmalıdır.");

            RuleFor(x => x.VideoUrl)
                .MaximumLength(500).WithMessage("Video URL en fazla 500 karakter olabilir.")
                .When(x => x.VideoUrl != null);

            RuleFor(x => x.BackgroundColor)
                .MaximumLength(50).WithMessage("Arkaplan rengi en fazla 50 karakter olabilir.")
                .When(x => x.BackgroundColor != null);
        }
    }
}
