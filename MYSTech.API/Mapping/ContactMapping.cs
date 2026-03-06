using AutoMapper;
using MYSTech.DTO.DTOs.ContactDTOs;
using MYSTech.Entity.Entities;

namespace MYSTech.API.Mapping
{
    public class ContactMapping : Profile
    {
        public ContactMapping() 
        {
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
        }
    }
}
