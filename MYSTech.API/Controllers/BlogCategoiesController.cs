using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYSTech.Business.Abstract;
using MYSTech.DTO.DTOs.BlogCategoryDTOs;
using MYSTech.DTO.DTOs.BlogDTOs;
using MYSTech.Entity.Entities;

namespace MYSTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCategoiesController(IGenericService<BlogCategory> _blogCategoryService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var blogCategories = _blogCategoryService.TGetList();
            return Ok(blogCategories);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var blogCategory = _blogCategoryService.TGetById(id);
            if (blogCategory == null)
            {
                return NotFound();
            }
            return Ok(blogCategory);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _blogCategoryService.TDelete(id);
            return Ok("Blog Kategorisi Silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateBlogCategoryDto createBlogCategoryDto)
        {
            var newBlogCategory = _mapper.Map<BlogCategory>(createBlogCategoryDto);
            _blogCategoryService.TCreate(newBlogCategory);
            return Ok("Blog Kategori Oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateBlogCategoryDto updateBlogCategoryDto)
        {
            var existingBlogCategoy = _mapper.Map<BlogCategory>(updateBlogCategoryDto);
            _blogCategoryService.TUpdate(existingBlogCategoy);
            return Ok("Blog Kategorisi Güncellendi");
        }
    }
}
