using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DTO.DTOs.BlogCategoryDTOs
{
    public class UpdateBlogCategoryDto
    {
        public int BlogCategoryId { get; set; }
        public string Name { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }
        public string IconUrl { get; set; }
        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<Blog> Blogs { get; set; } = new HashSet<Blog>();
    }
}
