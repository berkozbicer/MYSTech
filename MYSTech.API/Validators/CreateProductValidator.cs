using FluentValidation;
using MYSTech.DTO.DTOs.ProductDTOs;

namespace MYSTech.API.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Ürün adı boş olamaz.")
                .MaximumLength(300).WithMessage("Ürün adı en fazla 300 karakter olabilir.");

            RuleFor(x => x.Slug)
                .NotEmpty().WithMessage("Slug boş olamaz.")
                .MaximumLength(300).WithMessage("Slug en fazla 300 karakter olabilir.")
                .Matches("^[a-z0-9-]+$").WithMessage("Slug sadece küçük harf, rakam ve tire içerebilir.");

            RuleFor(x => x.FullDescription)
                .NotEmpty().WithMessage("Tam açıklama boş olamaz.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır.");

            RuleFor(x => x.DiscountPrice)
                .GreaterThan(0).WithMessage("İndirimli fiyat 0'dan büyük olmalıdır.")
                .LessThan(x => x.Price).WithMessage("İndirimli fiyat normal fiyattan düşük olmalıdır.")
                .When(x => x.DiscountPrice.HasValue);

            RuleFor(x => x.StockQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("Stok miktarı 0 veya daha büyük olmalıdır.");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Geçerli bir kategori seçiniz.");

            RuleFor(x => x.MetaTitle)
                .NotEmpty().WithMessage("Meta başlık boş olamaz.")
                .MaximumLength(200).WithMessage("Meta başlık en fazla 200 karakter olabilir.");
        }
    }

}
