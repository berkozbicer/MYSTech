using AutoMapper;
using MYSTech.Business.Abstract;
using MYSTech.DataAccess.Abstract;
using MYSTech.DTO.DTOs.ProductDTOs;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Business.Concrete
{
    public class ProductManager : GenericManager<Product, ResultProductListDto, CreateProductDto, UpdateProductDto>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            _productRepository = repository;
        }

        public async Task<ResultProductDetailDto> TGetDetailAsync(int productId)
        {
            var entity = await _productRepository.GetDetailAsync(productId);
            return _mapper.Map<ResultProductDetailDto>(entity);
        }

        public async Task<ResultProductDetailDto> TGetDetailBySlugAsync(string slug)
        {
            var entity = await _productRepository.GetDetailBySlugAsync(slug);
            return _mapper.Map<ResultProductDetailDto>(entity);
        }

        public async Task<List<ResultProductListDto>> TGetActiveByCategoryAsync(int categoryId)
        {
            var entities = await _productRepository.GetFilteredListAsync(x => x.IsActive && x.CategoryId == categoryId);
            return _mapper.Map<List<ResultProductListDto>>(entities);
        }

        public async Task<List<ResultProductListDto>> TGetHomeShownProductsAsync()
        {
            var entities = await _productRepository.GetFilteredListAsync(x => x.IsActive && x.IsHomeShown);
            return _mapper.Map<List<ResultProductListDto>>(entities);
        }
    }
}
