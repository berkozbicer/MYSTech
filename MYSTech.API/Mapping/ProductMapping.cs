using AutoMapper;
using MYSTech.DTO.DTOs.ProductDTOs;
using MYSTech.Entity.Entities;

namespace MYSTech.API.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ResultProductListDto>()
                .ForMember(dest => dest.CategoryName,
                           opt => opt.MapFrom(src => src.Category != null ? src.Category.CategoryName : null))
                .ForMember(dest => dest.MainImageUrl,
                           opt => opt.MapFrom(src => src.ProductImages != null
                               ? src.ProductImages.Where(i => i.IsMain).Select(i => i.ImageUrl).FirstOrDefault()
                               : null));

            CreateMap<Product, ResultProductDetailDto>()
                .ForMember(dest => dest.CategoryName,
                           opt => opt.MapFrom(src => src.Category != null ? src.Category.CategoryName : null))
                .ForMember(dest => dest.CategorySlug,
                           opt => opt.MapFrom(src => src.Category != null ? src.Category.Slug : null))
                .ForMember(dest => dest.Images,
                           opt => opt.MapFrom(src => src.ProductImages))
                .ForMember(dest => dest.Features,
                           opt => opt.MapFrom(src => src.ProductFeatures));

            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
        }
    }
}
