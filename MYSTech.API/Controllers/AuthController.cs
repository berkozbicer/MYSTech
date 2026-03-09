using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MYSTech.API.Models;
using MYSTech.Business.Abstract;
using MYSTech.DTO.DTOs.AuthDTOs;
using MYSTech.Entity.Entities;

namespace MYSTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AuthController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
            if (existingUser != null)
                return BadRequest(ApiResponse<object>.FailResponse("Bu e-posta adresi zaten kullanılıyor."));

            var user = new AppUser
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                UserName = registerDto.UserName,
                Email = registerDto.Email,
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                return BadRequest(ApiResponse<object>.FailResponse(errors, "Kayıt oluşturulamadı."));
            }

            await _userManager.AddToRoleAsync(user, "User");
            return Ok(ApiResponse<object>.SuccessResponse(null, "Kayıt başarıyla oluşturuldu."));
        }

        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<TokenResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null || !user.IsActive)
                return Unauthorized(ApiResponse<object>.FailResponse("E-posta veya şifre hatalı."));

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, lockoutOnFailure: true);
            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                    return Unauthorized(ApiResponse<object>.FailResponse("Hesabınız kilitlendi. Lütfen daha sonra tekrar deneyiniz."));

                return Unauthorized(ApiResponse<object>.FailResponse("E-posta veya şifre hatalı."));
            }

            var roles = await _userManager.GetRolesAsync(user);
            var tokenResponse = await _tokenService.GenerateTokenAsync(user, roles);

            user.RefreshToken = tokenResponse.RefreshToken;
            user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);
            await _userManager.UpdateAsync(user);

            return Ok(ApiResponse<TokenResponseDto>.SuccessResponse(tokenResponse, "Giriş başarılı."));
        }

        [HttpPost("refresh-token")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<TokenResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> RefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(refreshTokenDto.AccessToken);
            if (principal == null)
                return Unauthorized(ApiResponse<object>.FailResponse("Geçersiz token."));

            var email = principal.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
            var user = await _userManager.FindByEmailAsync(email!);

            if (user == null ||
                user.RefreshToken != refreshTokenDto.RefreshToken ||
                user.RefreshTokenExpiry <= DateTime.UtcNow)
            {
                return Unauthorized(ApiResponse<object>.FailResponse("Refresh token geçersiz veya süresi dolmuş."));
            }

            var roles = await _userManager.GetRolesAsync(user);
            var tokenResponse = await _tokenService.GenerateTokenAsync(user, roles);

            user.RefreshToken = tokenResponse.RefreshToken;
            user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);
            await _userManager.UpdateAsync(user);

            return Ok(ApiResponse<TokenResponseDto>.SuccessResponse(tokenResponse, "Token yenilendi."));
        }

        [HttpPost("logout")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Logout()
        {
            var email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
            var user = await _userManager.FindByEmailAsync(email!);

            if (user != null)
            {
                user.RefreshToken = null;
                user.RefreshTokenExpiry = null;
                await _userManager.UpdateAsync(user);
            }

            return Ok(ApiResponse<object>.SuccessResponse(null, "Çıkış başarılı."));
        }

        [HttpGet("me")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Me()
        {
            var email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
            var user = await _userManager.FindByEmailAsync(email!);
            if (user == null)
                return NotFound(ApiResponse<object>.FailResponse("Kullanıcı bulunamadı."));

            var roles = await _userManager.GetRolesAsync(user);

            return Ok(ApiResponse<object>.SuccessResponse(new
            {
                user.Id,
                user.FirstName,
                user.LastName,
                user.Email,
                user.UserName,
                user.ProfileImageUrl,
                user.CreatedDate,
                Roles = roles
            }));
        }
    }
}