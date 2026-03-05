using AutoMapper;
using MYSTech.DTO.DTOs.BannerDTOs;
using MYSTech.Entity.Entities;

namespace MYSTech.API.Mapping
{
    public class BannerMapping : Profile
    {
        public BannerMapping()
        {
            CreateMap<CreateBannerDto, Banner>().ReverseMap();
            CreateMap<UpdateBannerDto, Banner>().ReverseMap();
        }
    }
}
