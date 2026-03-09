using AutoMapper;
using MYSTech.DTO.DTOs.BannerDTOs;
using MYSTech.Entity.Entities;

namespace MYSTech.API.Mapping
{
    public class BannerMapping : Profile
    {
        public BannerMapping()
        {
            CreateMap<Banner, ResultBannerDto>();
            CreateMap<CreateBannerDto, Banner>();
            CreateMap<UpdateBannerDto, Banner>();
        }
    }
}
