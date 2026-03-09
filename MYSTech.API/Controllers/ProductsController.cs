using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYSTech.API.Models;
using MYSTech.Business.Abstract;
using MYSTech.DTO.DTOs.ProductDTOs;

namespace MYSTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsController(IProductService _productService) : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<List<ResultProductListDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetList()
        {
            var products = await _productService.TGetListAsync();
            return Ok(ApiResponse<List<ResultProductListDto>>.SuccessResponse(products));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<ResultProductListDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.TGetByIdAsync(id);
            if (product == null)
                return NotFound(ApiResponse<object>.FailResponse("Kayıt bulunamadı."));
            return Ok(ApiResponse<ResultProductListDto>.SuccessResponse(product));
        }

        [HttpGet("{id}/detail")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<ResultProductDetailDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDetail(int id)
        {
            var product = await _productService.TGetDetailAsync(id);
            if (product == null)
                return NotFound(ApiResponse<object>.FailResponse("Kayıt bulunamadı."));
            return Ok(ApiResponse<ResultProductDetailDto>.SuccessResponse(product));
        }

        [HttpGet("slug/{slug}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<ResultProductDetailDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBySlug(string slug)
        {
            var product = await _productService.TGetDetailBySlugAsync(slug);
            if (product == null)
                return NotFound(ApiResponse<object>.FailResponse("Kayıt bulunamadı."));
            return Ok(ApiResponse<ResultProductDetailDto>.SuccessResponse(product));
        }

        [HttpGet("category/{categoryId}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<List<ResultProductListDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            var products = await _productService.TGetActiveByCategoryAsync(categoryId);
            return Ok(ApiResponse<List<ResultProductListDto>>.SuccessResponse(products));
        }

        [HttpGet("home")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApiResponse<List<ResultProductListDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHomeShown()
        {
            var products = await _productService.TGetHomeShownProductsAsync();
            return Ok(ApiResponse<List<ResultProductListDto>>.SuccessResponse(products));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateProductDto createProductDto)
        {
            await _productService.TCreateAsync(createProductDto);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Ürün oluşturuldu."));
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
        {
            await _productService.TUpdateAsync(updateProductDto);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Ürün güncellendi."));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.TDeleteAsync(id);
            return Ok(ApiResponse<object>.SuccessResponse(null, "Ürün silindi."));
        }
    }
}
