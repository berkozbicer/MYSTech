using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DTO.DTOs.AboutDTOs
{
    public class ResultAboutDto
    {
        public int AboutId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
