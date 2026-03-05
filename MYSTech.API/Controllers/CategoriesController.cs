using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYSTech.Business.Abstract;
using MYSTech.DTO.DTOs.CategoryDTOs;
using MYSTech.Entity.Entities;

namespace MYSTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(IGenericService<Category> _categoryService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var categories = _categoryService.TGetList();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _categoryService.TGetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _categoryService.TDelete(id);
            return Ok("Kategori Silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryDto createCategoryDto)
        {
            var newCategory = _mapper.Map<Category>(createCategoryDto);
            _categoryService.TCreate(newCategory);
            return Ok("Kategori Oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateCategoryDto updateCategoryDto)
        {
            var existingCategory = _mapper.Map<Category>(updateCategoryDto);
            _categoryService.TUpdate(existingCategory);
            return Ok("Kategori Güncellendi");
        }
    }
}