using AutoMapper;
using MYSTech.Business.Abstract;
using MYSTech.DataAccess.Abstract;
using MYSTech.DTO.DTOs.ProductFeatureDTOs;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Business.Concrete
{
    public class ProductFeatureManager : GenericManager<ProductFeature, ResultProductFeatureDto, CreateProductFeatureDto, UpdateProductFeatureDto>, IProductFeatureService
    {
        private readonly IRepository<ProductFeature> _productFeatureRepository;

        public ProductFeatureManager(IRepository<ProductFeature> repository, IMapper mapper)
            : base(repository, mapper)
        {
            _productFeatureRepository = repository;
        }

        public async Task<List<ResultProductFeatureDto>> TGetByProductAsync(int productId)
        {
            var entities = await _productFeatureRepository.GetFilteredListAsync(x => x.ProductId == productId);
            return _mapper.Map<List<ResultProductFeatureDto>>(entities);
        }
    }
}
