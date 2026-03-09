using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DTO.DTOs.TestimonialDTOs
{
    public class CreateTestimonialDto
    {
        public string TestimonialName { get; set; }
        public string Title { get; set; }
        public string TestimonialDescription { get; set; }
        public string TestimonialImageUrl { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
