using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DTO.DTOs.AuthDTOs
{
    public class RefreshTokenDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
