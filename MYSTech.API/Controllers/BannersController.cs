using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYSTech.API.Models;
using MYSTech.Business.Abstract;
using MYSTech.DTO.DTOs.BannerDTOs;
using MYSTech.DTO.DTOs.CategoryDTOs;
using MYSTech.Entity.Entities;

namespace MYSTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BannersController(IBannerService _bannerService) : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<List<ResultBannerDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetList()
        {
            var banners = await _bannerService.TGetListAsync();
            return Ok(ApiResponse<List<ResultBannerDto>>.SuccessResponse(banners));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<ResultBannerDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var banner = await _bannerService.TGetByIdAsync(id);
            if (banner == null)
                return NotFound(ApiResponse<object>.FailResponse("Kayıt bulunamadı."));
            return Ok(ApiResponse<ResultBannerDto>.SuccessResponse(banner));
        }

        [HttpGet("active")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<List<ResultBannerDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetActive()
        {
            var banners = await _bannerService.TGetActiveBannersAsync();
            return Ok(ApiResponse<List<ResultBannerDto>>.SuccessResponse(banners));
        }

        [HttpGet("ordered")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<List<ResultBannerDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetOrdered()
        {
            var banners = await _bannerService.TGetOrderedBannersAsync();
            return Ok(ApiResponse<List<ResultBannerDto>>.SuccessResponse(banners));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateBannerDto createBannerDto)
        {
            await _bannerService.TCreateAsync(createBannerDto);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Banner oluşturuldu."));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateBannerDto updateBannerDto)
        {
            await _bannerService.TUpdateAsync(updateBannerDto);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Banner güncellendi."));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _bannerService.TDeleteAsync(id);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Banner silindi."));
        }
    }

}
