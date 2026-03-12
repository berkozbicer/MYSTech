using FluentValidation;
using MYSTech.DTO.DTOs.ContactDTOs;

namespace MYSTech.API.Validators
{
    public class CreateContactValidator : AbstractValidator<CreateContactDto>
    {
        public CreateContactValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Ad soyad boş olamaz.")
                .MaximumLength(200).WithMessage("Ad soyad en fazla 200 karakter olabilir.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.")
                .MaximumLength(200).WithMessage("E-posta en fazla 200 karakter olabilir.");

            RuleFor(x => x.Phone)
                .MaximumLength(50).WithMessage("Telefon en fazla 50 karakter olabilir.")
                .When(x => x.Phone != null);

            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("Konu boş olamaz.")
                .MaximumLength(300).WithMessage("Konu en fazla 300 karakter olabilir.");

            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Mesaj boş olamaz.")
                .MinimumLength(10).WithMessage("Mesaj en az 10 karakter olmalıdır.")
                .MaximumLength(2000).WithMessage("Mesaj en fazla 2000 karakter olabilir.");
        }
    }
}
