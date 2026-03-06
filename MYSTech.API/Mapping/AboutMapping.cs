using AutoMapper;

namespace MYSTech.API.Mapping
{
    public class AboutMapping : Profile
    {
        public AboutMapping() 
        {
            CreateMap<Entity.Entities.About, DTO.DTOs.AboutDTOs.CreateAboutDto>().ReverseMap();
            CreateMap<Entity.Entities.About, DTO.DTOs.AboutDTOs.UpdateAboutDto>().ReverseMap();
        }
    }
}
