using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYSTech.API.Models;
using MYSTech.Business.Abstract;
using MYSTech.DTO.DTOs.AboutDTOs;
using MYSTech.DTO.DTOs.BannerDTOs;
using MYSTech.Entity.Entities;

namespace MYSTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AboutsController(IAboutService _aboutService) : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<List<ResultAboutDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetList()
        {
            var abouts = await _aboutService.TGetListAsync();
            return Ok(ApiResponse<List<ResultAboutDto>>.SuccessResponse(abouts));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<ResultAboutDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var about = await _aboutService.TGetByIdAsync(id);
            if (about == null)
                return NotFound(ApiResponse<object>.FailResponse("Kayıt bulunamadı."));
            return Ok(ApiResponse<ResultAboutDto>.SuccessResponse(about));
        }

        [HttpGet("first")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<ResultAboutDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFirst()
        {
            var about = await _aboutService.TGetFirstAsync();
            if (about == null)
                return NotFound(ApiResponse<object>.FailResponse("Kayıt bulunamadı."));
            return Ok(ApiResponse<ResultAboutDto>.SuccessResponse(about));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateAboutDto createAboutDto)
        {
            await _aboutService.TCreateAsync(createAboutDto);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Hakkında oluşturuldu."));
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateAboutDto updateAboutDto)
        {
            await _aboutService.TUpdateAsync(updateAboutDto);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Hakkında güncellendi."));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _aboutService.TDeleteAsync(id);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Hakkında silindi."));
        }
    }
}
