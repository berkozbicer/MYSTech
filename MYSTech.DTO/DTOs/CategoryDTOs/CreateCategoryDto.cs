using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DTO.DTOs.CategoryDTOs
{
    public class CreateCategoryDto
    {

        public string CategoryName { get; set; }

        public string Slug { get; set; }

        public string Icon { get; set; }

        public string Description { get; set; }

        public bool IsShown { get; set; }

        public string MetaTitle { get; set; }

        public string MetaDescription { get; set; }

        public int? ParentCategoryId { get; set; }

        public Category ParentCategory { get; set; }

        public ICollection<Category> SubCategories { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
