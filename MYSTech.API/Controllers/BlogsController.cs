using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYSTech.Business.Abstract;
using MYSTech.DTO.DTOs.BannerDTOs;
using MYSTech.DTO.DTOs.BlogDTOs;
using MYSTech.Entity.Entities;

namespace MYSTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController(IGenericService<Blog> _blogService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var blogs = _blogService.TGetList();
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var blog = _blogService.TGetById(id);
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _blogService.TDelete(id);
            return Ok("Blog Silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateBlogDto createBlogDto)
        {
            var newBlog = _mapper.Map<Blog>(createBlogDto);
            _blogService.TCreate(newBlog);
            return Ok("Blog Oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateBlogDto updateBlogDto)
        {
            var existingBlog = _mapper.Map<Blog>(updateBlogDto);
            _blogService.TUpdate(existingBlog);
            return Ok("Blog Güncellendi");
        }
    }
}
