using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYSTech.Business.Services;

namespace MYSTech.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomePageController : ControllerBase
    {
        private readonly BannerService _bannerService;
        private readonly ProductService _productService;

        public HomePageController(BannerService bannerService, ProductService productService)
        {
            _bannerService = bannerService;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetHomePageData()
        {
            var banners = await _bannerService.GetActiveBannersAsync();
            var featuredProducts = await _productService.GetHomeProductsAsync();

            var result = new
            {
                Banners = banners,
                FeaturedProducts = featuredProducts
            };

            return Ok(result);
        }
    }
}
