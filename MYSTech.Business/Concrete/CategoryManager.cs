using AutoMapper;
using MYSTech.Business.Abstract;
using MYSTech.DataAccess.Abstract;
using MYSTech.DTO.DTOs.CategoryDTOs;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Business.Concrete
{
    public class CategoryManager : GenericManager<Category, ResultCategoryDto, CreateCategoryDto, UpdateCategoryDto>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            _categoryRepository = repository;
        }

        public async Task<ResultCategoryWithSubsDto> TGetWithSubCategoriesAsync(int categoryId)
        {
            var entity = await _categoryRepository.GetWithSubCategoriesAsync(categoryId);
            return _mapper.Map<ResultCategoryWithSubsDto>(entity);
        }

        public async Task<List<ResultCategoryDto>> TGetMainCategoriesAsync()
        {
            var entities = await _categoryRepository.GetFilteredListAsync(x => x.ParentCategoryId == null);
            return _mapper.Map<List<ResultCategoryDto>>(entities);
        }

        public async Task<List<ResultCategoryDto>> TGetSubCategoriesAsync(int parentId)
        {
            var entities = await _categoryRepository.GetFilteredListAsync(x => x.ParentCategoryId == parentId);
            return _mapper.Map<List<ResultCategoryDto>>(entities);
        }

        public async Task<ResultCategoryDto> TGetBySlugAsync(string slug)
        {
            var entity = await _categoryRepository.GetByFilterAsync(x => x.Slug == slug);
            return _mapper.Map<ResultCategoryDto>(entity);
        }
    }
}
