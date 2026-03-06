using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Entity.Entities
{
    public class Contact : BaseEntity
    {
        public int ContactId { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string Address { get; set; }
    }
}
