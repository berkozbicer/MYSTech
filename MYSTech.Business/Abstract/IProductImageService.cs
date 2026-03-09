using MYSTech.DTO.DTOs.ProductImageDTOs;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Business.Abstract
{
    public interface IProductImageService
        : IGenericService<ProductImage, ResultProductImageDto, CreateProductImageDto, UpdateProductImageDto>
    {
        Task<List<ResultProductImageDto>> TGetByProductAsync(int productId);
        Task TSetMainImageAsync(int productImageId);
    }
}
