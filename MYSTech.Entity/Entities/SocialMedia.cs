using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Entity.Entities
{
    public class SocialMedia : BaseEntity
    {
        public int SocialMediaId { get; set; }

        public string Icon { get; set; }

        public string Url { get; set; }

        public string Title { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
