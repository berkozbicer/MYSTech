using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DTO.DTOs.BlogDTOs
{
    public class ResultBlogDetailDto
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string CoverImageUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public int ReadingTime { get; set; }
        public string MetaDescription { get; set; }
        public bool IsPublished { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int BlogCategoryId { get; set; }
        public string BlogCategoryName { get; set; }
        public string BlogCategorySlug { get; set; }
    }
}
