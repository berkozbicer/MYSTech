using MYSTech.DTO.DTOs.ProductFeatureDTOs;
using MYSTech.DTO.DTOs.ProductImageDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DTO.DTOs.ProductDTOs
{
    public class ResultProductDetailDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Slug { get; set; }
        public string? ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public int StockQuantity { get; set; }
        public bool IsHomeShown { get; set; }
        public bool IsActive { get; set; }
        public string MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategorySlug { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public List<ResultProductImageDto> Images { get; set; } = new();
        public List<ResultProductFeatureDto> Features { get; set; } = new();
    }
}
