using FluentValidation;
using MYSTech.DTO.DTOs.ProductImageDTOs;

namespace MYSTech.API.Validators
{
    public class CreateProductImageValidator : AbstractValidator<CreateProductImageDto>
    {
        public CreateProductImageValidator()
        {
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Geçerli bir ürün seçiniz.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Görsel URL boş olamaz.")
                .MaximumLength(500).WithMessage("Görsel URL en fazla 500 karakter olabilir.");

            RuleFor(x => x.Order)
                .GreaterThanOrEqualTo(0).WithMessage("Sıra 0 veya daha büyük olmalıdır.");
        }
    }
}
