using FluentValidation;
using MYSTech.DTO.DTOs.ProductImageDTOs;

namespace MYSTech.API.Validators
{
    public class UpdateProductImageValidator : AbstractValidator<UpdateProductImageDto>
    {
        public UpdateProductImageValidator()
        {
            RuleFor(x => x.ProductImageId)
                .GreaterThan(0).WithMessage("Geçerli bir ID giriniz.");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Geçerli bir ürün seçiniz.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Görsel URL boş olamaz.")
                .MaximumLength(500).WithMessage("Görsel URL en fazla 500 karakter olabilir.");
        }
    }
}
