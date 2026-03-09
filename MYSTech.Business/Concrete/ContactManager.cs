using AutoMapper;
using MYSTech.Business.Abstract;
using MYSTech.DataAccess.Abstract;
using MYSTech.DTO.DTOs.ContactDTOs;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Business.Concrete
{
    public class ContactManager : GenericManager<Contact, ResultContactDto, CreateContactDto, UpdateContactDto>, IContactService
    {
        public ContactManager(IRepository<Contact> repository, IMapper mapper)
            : base(repository, mapper) { }
    }
}
