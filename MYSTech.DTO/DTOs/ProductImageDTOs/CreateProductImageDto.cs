using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DTO.DTOs.ProductImageDTOs
{
    public class CreateProductImageDto
    {
        public int ProductId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsMain { get; set; } = false;
        public int Order { get; set; }
    }
}
