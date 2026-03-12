using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DTO.DTOs.ContactDTOs
{
    public class CreateContactDto
    {

        public string FullName { get; set; }

        public string Email { get; set; }

        public string? Phone { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
    }
}
