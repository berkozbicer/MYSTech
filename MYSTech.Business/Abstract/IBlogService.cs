using MYSTech.DTO.DTOs.BlogDTOs;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Business.Abstract
{
    public interface IBlogService
        : IGenericService<Blog, ResultBlogListDto, CreateBlogDto, UpdateBlogDto>
    {
        Task<ResultBlogDetailDto> TGetDetailAsync(int blogId);
        Task<ResultBlogDetailDto> TGetDetailBySlugAsync(string slug);
        Task<List<ResultBlogListDto>> TGetPublishedBlogsAsync();
        Task<List<ResultBlogListDto>> TGetBlogsByCategoryAsync(int blogCategoryId);
    }
}
