using MYSTech.DTO.DTOs.ProductFeatureDTOs;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Business.Abstract
{
    public interface IProductFeatureService
        : IGenericService<ProductFeature, ResultProductFeatureDto, CreateProductFeatureDto, UpdateProductFeatureDto>
    {
        Task<List<ResultProductFeatureDto>> TGetByProductAsync(int productId);
    }
}
