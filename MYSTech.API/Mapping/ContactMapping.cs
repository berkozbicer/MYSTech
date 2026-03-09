using AutoMapper;
using MYSTech.DTO.DTOs.ContactDTOs;
using MYSTech.Entity.Entities;

namespace MYSTech.API.Mapping
{
    public class ContactMapping : Profile
    {
        public ContactMapping()
        {
            CreateMap<Contact, ResultContactDto>();
            CreateMap<CreateContactDto, Contact>();
            CreateMap<UpdateContactDto, Contact>();
        }
    }
}
