using AutoMapper;
using MYSTech.Business.Abstract;
using MYSTech.DataAccess.Abstract;
using MYSTech.DTO.DTOs.ProductFeatureDTOs;
using MYSTech.DTO.DTOs.ProductImageDTOs;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Business.Concrete
{
    public class ProductImageManager : GenericManager<ProductImage, ResultProductImageDto, CreateProductImageDto, UpdateProductImageDto>, IProductImageService
    {
        private readonly IRepository<ProductImage> _productImageRepository;

        public ProductImageManager(IRepository<ProductImage> repository, IMapper mapper)
            : base(repository, mapper)
        {
            _productImageRepository = repository;
        }

        public async Task<List<ResultProductImageDto>> TGetByProductAsync(int productId)
        {
            var entities = await _productImageRepository.GetFilteredListAsync(x => x.ProductId == productId);
            return _mapper.Map<List<ResultProductImageDto>>(entities);
        }

        public async Task TSetMainImageAsync(int productImageId)
        {
            var image = await _productImageRepository.GetByIdAsync(productImageId);
            var allImages = await _productImageRepository.GetFilteredListAsync(x => x.ProductId == image.ProductId);
            foreach (var img in allImages)
            {
                img.IsMain = false;
                await _productImageRepository.UpdateAsync(img);
            }
            image.IsMain = true;
            await _productImageRepository.UpdateAsync(image);
        }
    }
}
