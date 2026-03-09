using FluentValidation;
using MYSTech.DTO.DTOs.TestimonialDTOs;

namespace MYSTech.API.Validators
{
    public class UpdateTestimonialValidator : AbstractValidator<UpdateTestimonialDto>
    {
        public UpdateTestimonialValidator()
        {
            RuleFor(x => x.TestimonialId)
                .GreaterThan(0).WithMessage("Geçerli bir ID giriniz.");

            RuleFor(x => x.TestimonialName)
                .NotEmpty().WithMessage("İsim boş olamaz.")
                .MaximumLength(200).WithMessage("İsim en fazla 200 karakter olabilir.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Unvan boş olamaz.")
                .MaximumLength(200).WithMessage("Unvan en fazla 200 karakter olabilir.");

            RuleFor(x => x.TestimonialDescription)
                .NotEmpty().WithMessage("Açıklama boş olamaz.")
                .MaximumLength(1000).WithMessage("Açıklama en fazla 1000 karakter olabilir.");

            RuleFor(x => x.TestimonialImageUrl)
                .NotEmpty().WithMessage("Görsel URL boş olamaz.")
                .MaximumLength(500).WithMessage("Görsel URL en fazla 500 karakter olabilir.");
        }
    }
}
