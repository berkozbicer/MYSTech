using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DTO.DTOs.SocialMediaDTOs
{
    public class UpdateSocialMediaDto
    {
        public int SocialMediaId { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}
