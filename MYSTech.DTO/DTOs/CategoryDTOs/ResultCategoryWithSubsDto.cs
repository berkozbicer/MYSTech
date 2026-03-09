using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DTO.DTOs.CategoryDTOs
{
    public class ResultCategoryWithSubsDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Slug { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public bool IsShown { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public int? ParentCategoryId { get; set; }
        public List<SubCategoryDto> SubCategories { get; set; } = new();
    }
}
