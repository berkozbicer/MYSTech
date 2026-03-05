using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYSTech.Business.Abstract;
using MYSTech.DTO.DTOs.BannerDTOs;
using MYSTech.DTO.DTOs.CategoryDTOs;
using MYSTech.Entity.Entities;

namespace MYSTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController(IGenericService<Banner> _bannerService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var banners = _bannerService.TGetList();
            return Ok(banners);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var banner = _bannerService.TGetById(id);
            if (banner == null)
            {
                return NotFound();
            }
            return Ok(banner);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _bannerService.TDelete(id);
            return Ok("Banner Silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateBannerDto createBannerDto)
        {
            var newBanner = _mapper.Map<Banner>(createBannerDto);
            _bannerService.TCreate(newBanner);
            return Ok("Banner Oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateBannerDto updateBannerDto)
        {
            var existingBanner = _mapper.Map<Banner>(updateBannerDto);
            _bannerService.TUpdate(existingBanner);
            return Ok("Banner Güncellendi");
        }
    }
}
