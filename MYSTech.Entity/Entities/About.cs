using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Entity.Entities
{
    public class About : BaseEntity
    {
        public int AboutId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string? ImageUrl { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
