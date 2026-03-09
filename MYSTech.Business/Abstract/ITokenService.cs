using MYSTech.DTO.DTOs.AuthDTOs;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace MYSTech.Business.Abstract
{
    public interface ITokenService
    {
        Task<TokenResponseDto> GenerateTokenAsync(AppUser user, IList<string> roles);
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
        string GenerateRefreshToken();
    }
}
