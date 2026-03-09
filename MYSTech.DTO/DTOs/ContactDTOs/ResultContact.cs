using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DTO.DTOs.ContactDTOs
{
    public class ResultContactDto
    {
        public int ContactId { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
