using AutoMapper;
using MYSTech.Business.Abstract;
using MYSTech.DataAccess.Abstract;
using MYSTech.DTO.DTOs.BlogDTOs;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Business.Concrete
{
    public class BlogManager : GenericManager<Blog, ResultBlogListDto, CreateBlogDto, UpdateBlogDto>, IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogManager(IBlogRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            _blogRepository = repository;
        }

        public async Task<ResultBlogDetailDto> TGetDetailAsync(int blogId)
        {
            var entity = await _blogRepository.GetDetailAsync(blogId);
            return _mapper.Map<ResultBlogDetailDto>(entity);
        }

        public async Task<ResultBlogDetailDto> TGetDetailBySlugAsync(string slug)
        {
            var entity = await _blogRepository.GetDetailBySlugAsync(slug);
            return _mapper.Map<ResultBlogDetailDto>(entity);
        }

        public async Task<List<ResultBlogListDto>> TGetPublishedBlogsAsync()
        {
            var entities = await _blogRepository.GetFilteredListAsync(x => x.IsPublished);
            return _mapper.Map<List<ResultBlogListDto>>(entities);
        }

        public async Task<List<ResultBlogListDto>> TGetBlogsByCategoryAsync(int blogCategoryId)
        {
            var entities = await _blogRepository.GetFilteredListAsync(x => x.BlogCategoryId == blogCategoryId);
            return _mapper.Map<List<ResultBlogListDto>>(entities);
        }
    }
}
