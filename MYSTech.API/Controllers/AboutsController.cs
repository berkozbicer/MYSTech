using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYSTech.Business.Abstract;
using MYSTech.DTO.DTOs.AboutDTOs;
using MYSTech.DTO.DTOs.BannerDTOs;
using MYSTech.Entity.Entities;

namespace MYSTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(IGenericService<About> _aboutService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var abouts = _aboutService.TGetList();
            return Ok(abouts);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var about = _aboutService.TGetById(id);
            if (about == null)
            {
                return NotFound();
            }
            return Ok(about);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _aboutService.TDelete(id);
            return Ok("Hakkında Bilgisi Silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateAboutDto createAboutDto)
        {
            var newAbout = _mapper.Map<About>(createAboutDto);
            _aboutService.TCreate(newAbout);
            return Ok("Hakkında Oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateAboutDto updateAboutDto)
        {
            var existingAbout = _mapper.Map<About>(updateAboutDto);
            _aboutService.TUpdate(existingAbout);
            return Ok("Hakkında Bilgisi Güncellendi");
        }
    }
}
