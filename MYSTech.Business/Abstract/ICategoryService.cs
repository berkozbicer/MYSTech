using MYSTech.DTO.DTOs.CategoryDTOs;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Business.Abstract
{
    public interface ICategoryService
        : IGenericService<Category, ResultCategoryDto, CreateCategoryDto, UpdateCategoryDto>
    {
        Task<ResultCategoryWithSubsDto> TGetWithSubCategoriesAsync(int categoryId);
        Task<List<ResultCategoryDto>> TGetMainCategoriesAsync();
        Task<List<ResultCategoryDto>> TGetSubCategoriesAsync(int parentId);
        Task<ResultCategoryDto> TGetBySlugAsync(string slug);
    }
}
