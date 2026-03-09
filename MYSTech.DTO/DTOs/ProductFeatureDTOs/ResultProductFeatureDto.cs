using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DTO.DTOs.ProductFeatureDTOs
{
    public class ResultProductFeatureDto
    {
        public int ProductFeatureId { get; set; }
        public int ProductId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
