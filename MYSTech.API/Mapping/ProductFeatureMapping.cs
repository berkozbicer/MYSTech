using AutoMapper;
using MYSTech.DTO.DTOs.ProductFeatureDTOs;
using MYSTech.Entity.Entities;

namespace MYSTech.API.Mapping
{
    public class ProductFeatureMapping : Profile
    {
        public ProductFeatureMapping()
        {
            CreateMap<ProductFeature, ResultProductFeatureDto>();
            CreateMap<CreateProductFeatureDto, ProductFeature>();
            CreateMap<UpdateProductFeatureDto, ProductFeature>();
        }
    }
}
