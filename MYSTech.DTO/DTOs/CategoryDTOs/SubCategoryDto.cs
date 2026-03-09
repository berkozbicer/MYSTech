using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DTO.DTOs.CategoryDTOs
{
    public class SubCategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Slug { get; set; }
        public string Icon { get; set; }
    }
}
