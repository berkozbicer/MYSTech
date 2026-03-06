using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DTO.DTOs.ProductFeatureDTOs
{
    public class UpdateProductFeature
    {
        public int ProductFeatureId { get; set; }
        public int ProductId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public Product Product { get; set; }
    }
}
