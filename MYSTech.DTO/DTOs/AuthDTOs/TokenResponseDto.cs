using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DTO.DTOs.AuthDTOs
{
    public class TokenResponseDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime AccessTokenExpiry { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public IList<string> Roles { get; set; }
    }
}
