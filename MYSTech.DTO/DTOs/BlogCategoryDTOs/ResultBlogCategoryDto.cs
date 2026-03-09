using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DTO.DTOs.BlogCategoryDTOs
{
    public class ResultBlogCategoryDto
    {
        public int BlogCategoryId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public int BlogCount { get; set; }
    }
}
