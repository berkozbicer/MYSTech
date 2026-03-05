using AutoMapper;
using MYSTech.DTO.DTOs.CategoryDTOs;
using MYSTech.Entity.Entities;

namespace MYSTech.API.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<CreateCategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
        }
    }
}
