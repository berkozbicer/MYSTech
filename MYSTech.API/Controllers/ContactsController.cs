using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYSTech.API.Models;
using MYSTech.Business.Abstract;
using MYSTech.DTO.DTOs.BannerDTOs;
using MYSTech.DTO.DTOs.ContactDTOs;
using MYSTech.Entity.Entities;
using Microsoft.AspNetCore.RateLimiting;

namespace MYSTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [EnableRateLimiting("GeneralPolicy")]
    public class ContactsController(IContactService _contactService) : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<List<ResultContactDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetList()
        {
            var contacts = await _contactService.TGetListAsync();
            return Ok(ApiResponse<List<ResultContactDto>>.SuccessResponse(contacts));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<ResultContactDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _contactService.TGetByIdAsync(id);
            if (contact == null)
                return NotFound(ApiResponse<object>.FailResponse("Kayıt bulunamadı."));
            return Ok(ApiResponse<ResultContactDto>.SuccessResponse(contact));
        }

        [HttpPost]
        [AllowAnonymous]
        [EnableRateLimiting("ContactFormPolicy")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateContactDto createContactDto)
        {
            await _contactService.TCreateAsync(createContactDto);
            return Ok(ApiResponse<object>.SuccessResponse(null, "İletişim mesajı gönderildi."));
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateContactDto updateContactDto)
        {
            await _contactService.TUpdateAsync(updateContactDto);
            return Ok(ApiResponse<object>.SuccessResponse(null, "İletişim alanı güncellendi."));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _contactService.TDeleteAsync(id);
            return Ok(ApiResponse<object>.SuccessResponse(null, "İletişim alanı silindi."));
        }
    }
}
