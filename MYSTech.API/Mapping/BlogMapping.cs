using AutoMapper;
using MYSTech.DTO.DTOs.BlogDTOs;
using MYSTech.Entity.Entities;

namespace MYSTech.API.Mapping
{
    public class BlogMapping : Profile
    {
        public BlogMapping()
        {
            CreateMap<Blog, ResultBlogListDto>()
                .ForMember(dest => dest.BlogCategoryName,
                           opt => opt.MapFrom(src => src.BlogCategory != null ? src.BlogCategory.Name : null))
                .ForMember(dest => dest.BlogCategorySlug,
                           opt => opt.MapFrom(src => src.BlogCategory != null ? src.BlogCategory.Slug : null));

            CreateMap<Blog, ResultBlogDetailDto>()
                .ForMember(dest => dest.BlogCategoryName,
                           opt => opt.MapFrom(src => src.BlogCategory != null ? src.BlogCategory.Name : null))
                .ForMember(dest => dest.BlogCategorySlug,
                           opt => opt.MapFrom(src => src.BlogCategory != null ? src.BlogCategory.Slug : null));

            CreateMap<CreateBlogDto, Blog>();
            CreateMap<UpdateBlogDto, Blog>();
        }
    }
}
