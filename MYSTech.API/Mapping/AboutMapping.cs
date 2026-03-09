using AutoMapper;
using MYSTech.DTO.DTOs.AboutDTOs;
using MYSTech.Entity.Entities;

namespace MYSTech.API.Mapping
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<CreateAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();
        }
    }
}
