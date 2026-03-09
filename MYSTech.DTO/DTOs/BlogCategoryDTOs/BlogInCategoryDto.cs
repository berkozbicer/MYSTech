using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DTO.DTOs.BlogCategoryDTOs
{
    public class BlogInCategoryDto
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string ThumbnailUrl { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
