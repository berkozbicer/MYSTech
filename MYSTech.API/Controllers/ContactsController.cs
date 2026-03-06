using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYSTech.Business.Abstract;
using MYSTech.DTO.DTOs.BannerDTOs;
using MYSTech.DTO.DTOs.ContactDTOs;
using MYSTech.Entity.Entities;

namespace MYSTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(IGenericService<Contact> _contactService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var contacts = _contactService.TGetList();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _contactService.TGetById(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _contactService.TDelete(id);
            return Ok("İletiim Alanı Silindi");
        }

        [HttpPost]
        public IActionResult Create(CreateContactDto createContactDto)
        {
            var newContact = _mapper.Map<Contact>(createContactDto);
            _contactService.TCreate(newContact);
            return Ok("İletişim Alanı Oluşturuldu");
        }

        [HttpPut]
        public IActionResult Update(UpdateContactDto updateContactDto)
        {
            var existingContact = _mapper.Map<Contact>(updateContactDto);
            _contactService.TUpdate(existingContact);
            return Ok("İletişim Alanı Güncellendi");
        }
    }
}
