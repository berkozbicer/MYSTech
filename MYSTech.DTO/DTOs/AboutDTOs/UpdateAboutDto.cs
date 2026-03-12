using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DTO.DTOs.AboutDTOs
{
    public class UpdateAboutDto
    {
        public int AboutId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string? ImageUrl { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
