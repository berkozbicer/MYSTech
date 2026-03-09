using AutoMapper;
using MYSTech.DTO.DTOs.BlogCategoryDTOs;
using MYSTech.Entity.Entities;

namespace MYSTech.API.Mapping
{
    public class BlogCategoryMapping : Profile
    {
        public BlogCategoryMapping()
        {
            CreateMap<BlogCategory, ResultBlogCategoryDto>()
                .ForMember(dest => dest.BlogCount,
                           opt => opt.MapFrom(src => src.Blogs != null ? src.Blogs.Count : 0));

            CreateMap<BlogCategory, ResultBlogCategoryWithBlogsDto>()
                .ForMember(dest => dest.Blogs,
                           opt => opt.MapFrom(src => src.Blogs));

            CreateMap<Blog, BlogInCategoryDto>();

            CreateMap<CreateBlogCategoryDto, BlogCategory>();
            CreateMap<UpdateBlogCategoryDto, BlogCategory>();
        }
    }
}
