using AutoMapper;
using MYSTech.DTO.DTOs.BlogCategoryDTOs;
using MYSTech.Entity.Entities;

namespace MYSTech.API.Mapping
{
    public class BlogCategoryMapping : Profile
    {
        public BlogCategoryMapping() 
        {
            CreateMap<BlogCategory, ResultBlogCategoryDto>().ReverseMap();
            CreateMap<BlogCategory, CreateBlogCategoryDto>().ReverseMap();
            CreateMap<BlogCategory, UpdateBlogCategoryDto>().ReverseMap();
        }
    }
}
