using MYSTech.DTO.DTOs.BlogCategoryDTOs;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Business.Abstract
{
    public interface IBlogCategoryService
        : IGenericService<BlogCategory, ResultBlogCategoryDto, CreateBlogCategoryDto, UpdateBlogCategoryDto>
    {
        Task<ResultBlogCategoryWithBlogsDto> TGetWithBlogsAsync(int blogCategoryId);
        Task<List<ResultBlogCategoryDto>> TGetActiveCategoriesAsync();
        Task<ResultBlogCategoryDto> TGetBySlugAsync(string slug);
    }
}
