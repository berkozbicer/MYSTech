using MYSTech.DTO.DTOs.ProductDTOs;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Business.Abstract
{
    public interface IProductService
        : IGenericService<Product, ResultProductListDto, CreateProductDto, UpdateProductDto>
    {
        Task<ResultProductDetailDto> TGetDetailAsync(int productId);
        Task<ResultProductDetailDto> TGetDetailBySlugAsync(string slug);
        Task<List<ResultProductListDto>> TGetActiveByCategoryAsync(int categoryId);
        Task<List<ResultProductListDto>> TGetHomeShownProductsAsync();
    }
}
