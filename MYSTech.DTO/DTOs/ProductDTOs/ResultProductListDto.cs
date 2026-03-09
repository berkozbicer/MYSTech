using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DTO.DTOs.ProductDTOs
{
    public class ResultProductListDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Slug { get; set; }
        public string? ShortDescription { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public int StockQuantity { get; set; }
        public bool IsActive { get; set; }
        public bool IsHomeShown { get; set; }
        public string CategoryName { get; set; }
        public string? MainImageUrl { get; set; }
    }
}
