using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DTO.DTOs.ProductImageDTOs
{
    public class ResultProductImageDto
    {
        public int ProductImageId { get; set; }
        public int ProductId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsMain { get; set; }
        public int Order { get; set; }
    }
}
