using FluentValidation;
using MYSTech.DTO.DTOs.AuthDTOs;

namespace MYSTech.API.Validators
{
    public class RefreshTokenValidator : AbstractValidator<RefreshTokenDto>
    {
        public RefreshTokenValidator()
        {
            RuleFor(x => x.AccessToken)
                .NotEmpty().WithMessage("Access token boş olamaz.");

            RuleFor(x => x.RefreshToken)
                .NotEmpty().WithMessage("Refresh token boş olamaz.");
        }
    }
}
