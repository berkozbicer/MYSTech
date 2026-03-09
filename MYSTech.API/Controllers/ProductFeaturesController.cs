using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYSTech.API.Models;
using MYSTech.Business.Abstract;
using MYSTech.DTO.DTOs.ProductFeatureDTOs;

namespace MYSTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductFeaturesController(IProductFeatureService _productFeatureService) : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<List<ResultProductFeatureDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetList()
        {
            var features = await _productFeatureService.TGetListAsync();
            return Ok(ApiResponse<List<ResultProductFeatureDto>>.SuccessResponse(features));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<ResultProductFeatureDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var feature = await _productFeatureService.TGetByIdAsync(id);
            if (feature == null)
                return NotFound(ApiResponse<object>.FailResponse("Kayıt bulunamadı."));
            return Ok(ApiResponse<ResultProductFeatureDto>.SuccessResponse(feature));
        }

        [HttpGet("product/{productId}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<List<ResultProductFeatureDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByProduct(int productId)
        {
            var features = await _productFeatureService.TGetByProductAsync(productId);
            return Ok(ApiResponse<List<ResultProductFeatureDto>>.SuccessResponse(features));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateProductFeatureDto createProductFeatureDto)
        {
            await _productFeatureService.TCreateAsync(createProductFeatureDto);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Ürün özelliği eklendi."));
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateProductFeatureDto updateProductFeatureDto)
        {
            await _productFeatureService.TUpdateAsync(updateProductFeatureDto);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Ürün özelliği güncellendi."));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _productFeatureService.TDeleteAsync(id);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Ürün özelliği silindi."));
        }
    }
}
