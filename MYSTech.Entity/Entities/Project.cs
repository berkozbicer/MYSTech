using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Entity.Entities
{
    public class Project : BaseEntity
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string ImageUrl { get; set; }
        public string ClientName { get; set; }
        public string ProjectUrl { get; set; }
        public string Technologies { get; set; }
        public string Category { get; set; }
        public DateTime CompletedDate { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
    }
}
