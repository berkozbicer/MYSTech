using AutoMapper;
using MYSTech.DTO.DTOs.ProductImageDTOs;
using MYSTech.Entity.Entities;

namespace MYSTech.API.Mapping
{
    public class ProductImageMapping : Profile
    {
        public ProductImageMapping()
        {
            CreateMap<ProductImage, ResultProductImageDto>();
            CreateMap<CreateProductImageDto, ProductImage>();
            CreateMap<UpdateProductImageDto, ProductImage>();
        }
    }
}
