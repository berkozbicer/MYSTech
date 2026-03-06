using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Entity.Entities
{
    public class Blog : BaseEntity
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

        public int BlogCategoryId { get; set; }
        public BlogCategory BlogCategory { get; set; }
    }
}
