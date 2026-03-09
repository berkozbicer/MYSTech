using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYSTech.API.Models;
using MYSTech.Business.Abstract;
using MYSTech.DTO.DTOs.ProductImageDTOs;

namespace MYSTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductImagesController(IProductImageService _productImageService) : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<List<ResultProductImageDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetList()
        {
            var images = await _productImageService.TGetListAsync();
            return Ok(ApiResponse<List<ResultProductImageDto>>.SuccessResponse(images));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<ResultProductImageDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var image = await _productImageService.TGetByIdAsync(id);
            if (image == null)
                return NotFound(ApiResponse<object>.FailResponse("Kayıt bulunamadı."));
            return Ok(ApiResponse<ResultProductImageDto>.SuccessResponse(image));
        }

        [HttpGet("product/{productId}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<List<ResultProductImageDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            var images = await _productImageService.TGetByProductAsync(productId);
            return Ok(ApiResponse<List<ResultProductImageDto>>.SuccessResponse(images));
        }

        [HttpPatch("{id}/set-main")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SetMain(int id)
        {
            await _productImageService.TSetMainImageAsync(id);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Ana görsel güncellendi."));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateProductImageDto createProductImageDto)
        {
            await _productImageService.TCreateAsync(createProductImageDto);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Ürün görseli eklendi."));
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageService.TUpdateAsync(updateProductImageDto);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Ürün görseli güncellendi."));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _productImageService.TDeleteAsync(id);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Ürün görseli silindi."));
        }
    }
}
