using AutoMapper;
using MYSTech.DTO.DTOs.SocialMediaDTOs;
using MYSTech.Entity.Entities;

namespace MYSTech.API.Mapping
{
    public class SocialMediaMapping : Profile
    {
        public SocialMediaMapping()
        {
            CreateMap<SocialMedia, ResultSocialMediaDto>();
            CreateMap<CreateSocialMediaDto, SocialMedia>();
            CreateMap<UpdateSocialMediaDto, SocialMedia>();
        }
    }
}
