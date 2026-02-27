using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Entity.Entities
{
    public class Banner : BaseEntity
    {
        public int BannerId { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string ImageUrl { get; set; }

        public string MobileImageUrl { get; set; }

        public string ButtonText { get; set; }

        public string ButtonLink { get; set; }

        public int Order { get; set; }

        public bool IsActive { get; set; }

        public string? VideoUrl { get; set; }
        public string? BackgroundColor { get; set; }
    }
}
