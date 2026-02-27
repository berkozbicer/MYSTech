using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Entity.Entities
{
    public class Product : BaseEntity
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public string Slug { get; set; } = null!;

        public string? ShortDescription { get; set; }

        public string FullDescription { get; set; }

        public decimal Price { get; set; }

        public decimal? DiscountPrice { get; set; }

        public int StockQuantity { get; set; }

        public bool IsHomeShown { get; set; }

        public int CategoryId { get; set; }

        public string MetaTitle { get; set; }

        public string? MetaDescription { get; set; }

        public bool IsActive { get; set; }

        public Category Category { get; set; }


        public ICollection<ProductImage> ProductImages { get; set; }

        public ICollection<ProductFeature> ProductFeatures { get; set; }
    }
}
