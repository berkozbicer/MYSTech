using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYSTech.API.Models;
using MYSTech.Business.Abstract;
using MYSTech.DTO.DTOs.SocialMediaDTOs;

namespace MYSTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class SocialMediasController(ISocialMediaService _socialMediaService) : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<List<ResultSocialMediaDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetList()
        {
            var socialMedias = await _socialMediaService.TGetListAsync();
            return Ok(ApiResponse<List<ResultSocialMediaDto>>.SuccessResponse(socialMedias));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<ResultSocialMediaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var socialMedia = await _socialMediaService.TGetByIdAsync(id);
            if (socialMedia == null)
                return NotFound(ApiResponse<object>.FailResponse("Kayıt bulunamadı."));
            return Ok(ApiResponse<ResultSocialMediaDto>.SuccessResponse(socialMedia));
        }

        [HttpGet("active")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<List<ResultSocialMediaDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetActive()
        {
            var socialMedias = await _socialMediaService.TGetActiveAsync();
            return Ok(ApiResponse<List<ResultSocialMediaDto>>.SuccessResponse(socialMedias));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateSocialMediaDto createSocialMediaDto)
        {
            await _socialMediaService.TCreateAsync(createSocialMediaDto);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Sosyal medya eklendi."));
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateSocialMediaDto updateSocialMediaDto)
        {
            await _socialMediaService.TUpdateAsync(updateSocialMediaDto);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Sosyal medya güncellendi."));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _socialMediaService.TDeleteAsync(id);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Sosyal medya silindi."));
        }
    }
}
