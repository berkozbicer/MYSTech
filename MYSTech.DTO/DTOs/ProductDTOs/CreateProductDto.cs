using MYSTech.DTO.DTOs.ProductFeatureDTOs;
using MYSTech.DTO.DTOs.ProductImageDTOs;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DTO.DTOs.ProductDTOs
{
    public class CreateProductDto
    {
        public string ProductName { get; set; }
        public string Slug { get; set; }
        public string? ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public int StockQuantity { get; set; }
        public bool IsHomeShown { get; set; }
        public int CategoryId { get; set; }
        public string MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public bool IsActive { get; set; } = true;
        public List<CreateProductImageDto> Images { get; set; } = new();
        public List<CreateProductFeatureDto> Features { get; set; } = new();
    }
}
