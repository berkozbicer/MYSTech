using AutoMapper;
using MYSTech.DTO.DTOs.CategoryDTOs;
using MYSTech.Entity.Entities;

namespace MYSTech.API.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, ResultCategoryDto>()
                .ForMember(dest => dest.ParentCategoryName,
                           opt => opt.MapFrom(src => src.ParentCategory != null ? src.ParentCategory.CategoryName : null))
                .ForMember(dest => dest.ProductCount,
                           opt => opt.MapFrom(src => src.Products != null ? src.Products.Count : 0));

            CreateMap<Category, ResultCategoryWithSubsDto>()
                .ForMember(dest => dest.SubCategories,
                           opt => opt.MapFrom(src => src.SubCategories));

            CreateMap<Category, SubCategoryDto>();

            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
        }
    }
}
