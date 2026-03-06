using AutoMapper;
using MYSTech.DTO.DTOs.BlogDTOs;
using MYSTech.Entity.Entities;

namespace MYSTech.API.Mapping
{
    public class BlogMapping : Profile
    {
        public BlogMapping() 
        {
            CreateMap<Blog, ResultBlogDto>().ReverseMap();
            CreateMap<Blog, CreateBlogDto>().ReverseMap();
            CreateMap<Blog, UpdateBlogDto>().ReverseMap();
        }
    }
}
