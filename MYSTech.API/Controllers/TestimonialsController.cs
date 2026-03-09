using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYSTech.API.Models;
using MYSTech.Business.Abstract;
using MYSTech.DTO.DTOs.TestimonialDTOs;

namespace MYSTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TestimonialsController(ITestimonialService _testimonialService) : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<List<ResultTestimonialDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetList()
        {
            var testimonials = await _testimonialService.TGetListAsync();
            return Ok(ApiResponse<List<ResultTestimonialDto>>.SuccessResponse(testimonials));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<ResultTestimonialDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var testimonial = await _testimonialService.TGetByIdAsync(id);
            if (testimonial == null)
                return NotFound(ApiResponse<object>.FailResponse("Kayıt bulunamadı."));
            return Ok(ApiResponse<ResultTestimonialDto>.SuccessResponse(testimonial));
        }

        [HttpGet("active")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<List<ResultTestimonialDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetActive()
        {
            var testimonials = await _testimonialService.TGetActiveAsync();
            return Ok(ApiResponse<List<ResultTestimonialDto>>.SuccessResponse(testimonials));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateTestimonialDto createTestimonialDto)
        {
            await _testimonialService.TCreateAsync(createTestimonialDto);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Referans eklendi."));
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateTestimonialDto updateTestimonialDto)
        {
            await _testimonialService.TUpdateAsync(updateTestimonialDto);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Referans güncellendi."));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _testimonialService.TDeleteAsync(id);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Referans silindi."));
        }
    }
}
