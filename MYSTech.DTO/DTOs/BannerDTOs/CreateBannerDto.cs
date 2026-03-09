using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DTO.DTOs.BannerDTOs
{
    public class CreateBannerDto
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
        public string MobileImageUrl { get; set; }
        public string ButtonText { get; set; }
        public string ButtonLink { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; } = true;
        public string? VideoUrl { get; set; }
        public string? BackgroundColor { get; set; }
    }
}
