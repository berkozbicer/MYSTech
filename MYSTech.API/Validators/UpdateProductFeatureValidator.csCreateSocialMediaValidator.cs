using FluentValidation;
using MYSTech.DTO.DTOs.ProductFeatureDTOs;

namespace MYSTech.API.Validators
{
    public class UpdateProductFeatureValidator : AbstractValidator<UpdateProductFeatureDto>
    {
        public UpdateProductFeatureValidator()
        {
            RuleFor(x => x.ProductFeatureId)
                .GreaterThan(0).WithMessage("Geçerli bir ID giriniz.");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Geçerli bir ürün seçiniz.");

            RuleFor(x => x.Key)
                .NotEmpty().WithMessage("Özellik adı boş olamaz.")
                .MaximumLength(200).WithMessage("Özellik adı en fazla 200 karakter olabilir.");

            RuleFor(x => x.Value)
                .NotEmpty().WithMessage("Özellik değeri boş olamaz.")
                .MaximumLength(500).WithMessage("Özellik değeri en fazla 500 karakter olabilir.");
        }
    }
}
