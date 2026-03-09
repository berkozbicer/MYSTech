using FluentValidation;
using MYSTech.DTO.DTOs.ContactDTOs;

namespace MYSTech.API.Validators
{
    public class CreateContactValidator : AbstractValidator<CreateContactDto>
    {
        public CreateContactValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.")
                .MaximumLength(200).WithMessage("E-posta en fazla 200 karakter olabilir.");

            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Mesaj boş olamaz.")
                .MinimumLength(10).WithMessage("Mesaj en az 10 karakter olmalıdır.")
                .MaximumLength(2000).WithMessage("Mesaj en fazla 2000 karakter olabilir.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Adres boş olamaz.")
                .MaximumLength(500).WithMessage("Adres en fazla 500 karakter olabilir.");
        }
    }
}
