using MYSTech.DTO.DTOs.ContactDTOs;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Business.Abstract
{
    public interface IContactService
        : IGenericService<Contact, ResultContactDto, CreateContactDto, UpdateContactDto>
    {
    }
}
