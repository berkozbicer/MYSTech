using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYSTech.API.Models;
using MYSTech.Business.Abstract;
using MYSTech.DTO.DTOs.CategoryDTOs;
using MYSTech.Entity.Entities;

namespace MYSTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CategoriesController(ICategoryService _categoryService) : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<List<ResultCategoryDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetList()
        {
            var categories = await _categoryService.TGetListAsync();
            return Ok(ApiResponse<List<ResultCategoryDto>>.SuccessResponse(categories));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<ResultCategoryDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.TGetByIdAsync(id);
            if (category == null)
                return NotFound(ApiResponse<object>.FailResponse("Kayıt bulunamadı."));
            return Ok(ApiResponse<ResultCategoryDto>.SuccessResponse(category));
        }

        [HttpGet("{id}/with-subs")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<ResultCategoryWithSubsDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetWithSubCategories(int id)
        {
            var category = await _categoryService.TGetWithSubCategoriesAsync(id);
            if (category == null)
                return NotFound(ApiResponse<object>.FailResponse("Kayıt bulunamadı."));
            return Ok(ApiResponse<ResultCategoryWithSubsDto>.SuccessResponse(category));
        }

        [HttpGet("main")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<List<ResultCategoryDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMainCategories()
        {
            var categories = await _categoryService.TGetMainCategoriesAsync();
            return Ok(ApiResponse<List<ResultCategoryDto>>.SuccessResponse(categories));
        }

        [HttpGet("{parentId}/subs")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<List<ResultCategoryDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSubCategories(int parentId)
        {
            var categories = await _categoryService.TGetSubCategoriesAsync(parentId);
            return Ok(ApiResponse<List<ResultCategoryDto>>.SuccessResponse(categories));
        }

        [HttpGet("slug/{slug}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<ResultCategoryDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBySlug(string slug)
        {
            var category = await _categoryService.TGetBySlugAsync(slug);
            if (category == null)
                return NotFound(ApiResponse<object>.FailResponse("Kayıt bulunamadı."));
            return Ok(ApiResponse<ResultCategoryDto>.SuccessResponse(category));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.TCreateAsync(createCategoryDto);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Kategori oluşturuldu."));
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.TUpdateAsync(updateCategoryDto);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Kategori güncellendi."));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.TDeleteAsync(id);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Kategori silindi."));
        }
    }
}