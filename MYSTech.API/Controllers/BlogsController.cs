using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYSTech.API.Models;
using MYSTech.Business.Abstract;
using MYSTech.DTO.DTOs.BannerDTOs;
using MYSTech.DTO.DTOs.BlogDTOs;
using MYSTech.Entity.Entities;

namespace MYSTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BlogsController(IBlogService _blogService) : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<List<ResultBlogListDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetList()
        {
            var blogs = await _blogService.TGetListAsync();
            return Ok(ApiResponse<List<ResultBlogListDto>>.SuccessResponse(blogs));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<ResultBlogListDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await _blogService.TGetByIdAsync(id);
            if (blog == null)
                return NotFound(ApiResponse<object>.FailResponse("Kayıt bulunamadı."));
            return Ok(ApiResponse<ResultBlogListDto>.SuccessResponse(blog));
        }

        [HttpGet("{id}/detail")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<ResultBlogDetailDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDetail(int id)
        {
            var blog = await _blogService.TGetDetailAsync(id);
            if (blog == null)
                return NotFound(ApiResponse<object>.FailResponse("Kayıt bulunamadı."));
            return Ok(ApiResponse<ResultBlogDetailDto>.SuccessResponse(blog));
        }

        [HttpGet("slug/{slug}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<ResultBlogDetailDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBySlug(string slug)
        {
            var blog = await _blogService.TGetDetailBySlugAsync(slug);
            if (blog == null)
                return NotFound(ApiResponse<object>.FailResponse("Kayıt bulunamadı."));
            return Ok(ApiResponse<ResultBlogDetailDto>.SuccessResponse(blog));
        }

        [HttpGet("published")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<List<ResultBlogListDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPublished()
        {
            var blogs = await _blogService.TGetPublishedBlogsAsync();
            return Ok(ApiResponse<List<ResultBlogListDto>>.SuccessResponse(blogs));
        }

        [HttpGet("category/{categoryId}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<List<ResultBlogListDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            var blogs = await _blogService.TGetBlogsByCategoryAsync(categoryId);
            return Ok(ApiResponse<List<ResultBlogListDto>>.SuccessResponse(blogs));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateBlogDto createBlogDto)
        {
            await _blogService.TCreateAsync(createBlogDto);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Blog oluşturuldu."));
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateBlogDto updateBlogDto)
        {
            await _blogService.TUpdateAsync(updateBlogDto);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Blog güncellendi."));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _blogService.TDeleteAsync(id);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Blog silindi."));
        }
    }
}
