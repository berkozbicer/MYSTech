using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYSTech.API.Models;
using MYSTech.Business.Abstract;
using MYSTech.DTO.DTOs.BlogCategoryDTOs;
using MYSTech.DTO.DTOs.BlogDTOs;
using MYSTech.Entity.Entities;

namespace MYSTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BlogCategoriesController(IBlogCategoryService _blogCategoryService) : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<List<ResultBlogCategoryDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetList()
        {
            var blogCategories = await _blogCategoryService.TGetListAsync();
            return Ok(ApiResponse<List<ResultBlogCategoryDto>>.SuccessResponse(blogCategories));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<ResultBlogCategoryDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var blogCategory = await _blogCategoryService.TGetByIdAsync(id);
            if (blogCategory == null)
                return NotFound(ApiResponse<object>.FailResponse("Kayıt bulunamadı."));
            return Ok(ApiResponse<ResultBlogCategoryDto>.SuccessResponse(blogCategory));
        }

        [HttpGet("{id}/with-blogs")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<ResultBlogCategoryWithBlogsDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetWithBlogs(int id)
        {
            var blogCategory = await _blogCategoryService.TGetWithBlogsAsync(id);
            if (blogCategory == null)
                return NotFound(ApiResponse<object>.FailResponse("Kayıt bulunamadı."));
            return Ok(ApiResponse<ResultBlogCategoryWithBlogsDto>.SuccessResponse(blogCategory));
        }

        [HttpGet("active")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<List<ResultBlogCategoryDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetActive()
        {
            var blogCategories = await _blogCategoryService.TGetActiveCategoriesAsync();
            return Ok(ApiResponse<List<ResultBlogCategoryDto>>.SuccessResponse(blogCategories));
        }

        [HttpGet("slug/{slug}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<ResultBlogCategoryDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBySlug(string slug)
        {
            var blogCategory = await _blogCategoryService.TGetBySlugAsync(slug);
            if (blogCategory == null)
                return NotFound(ApiResponse<object>.FailResponse("Kayıt bulunamadı."));
            return Ok(ApiResponse<ResultBlogCategoryDto>.SuccessResponse(blogCategory));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateBlogCategoryDto createBlogCategoryDto)
        {
            await _blogCategoryService.TCreateAsync(createBlogCategoryDto);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Blog kategorisi oluşturuldu."));
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateBlogCategoryDto updateBlogCategoryDto)
        {
            await _blogCategoryService.TUpdateAsync(updateBlogCategoryDto);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Blog kategorisi güncellendi."));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _blogCategoryService.TDeleteAsync(id);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Blog kategorisi silindi."));
        }
    }
}
