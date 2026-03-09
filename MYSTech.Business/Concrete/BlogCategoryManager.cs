using AutoMapper;
using MYSTech.Business.Abstract;
using MYSTech.DataAccess.Abstract;
using MYSTech.DTO.DTOs.BlogCategoryDTOs;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Business.Concrete
{
    public class BlogCategoryManager : GenericManager<BlogCategory, ResultBlogCategoryDto, CreateBlogCategoryDto, UpdateBlogCategoryDto>, IBlogCategoryService
    {
        private readonly IBlogCategoryRepository _blogCategoryRepository;

        public BlogCategoryManager(IBlogCategoryRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            _blogCategoryRepository = repository;
        }

        public async Task<ResultBlogCategoryWithBlogsDto> TGetWithBlogsAsync(int blogCategoryId)
        {
            var entity = await _blogCategoryRepository.GetWithBlogsAsync(blogCategoryId);
            return _mapper.Map<ResultBlogCategoryWithBlogsDto>(entity);
        }

        public async Task<List<ResultBlogCategoryDto>> TGetActiveCategoriesAsync()
        {
            var entities = await _blogCategoryRepository.GetFilteredListAsync(x => x.IsActive);
            return _mapper.Map<List<ResultBlogCategoryDto>>(entities);
        }

        public async Task<ResultBlogCategoryDto> TGetBySlugAsync(string slug)
        {
            var entity = await _blogCategoryRepository.GetByFilterAsync(x => x.Slug == slug);
            return _mapper.Map<ResultBlogCategoryDto>(entity);
        }
    }
}
