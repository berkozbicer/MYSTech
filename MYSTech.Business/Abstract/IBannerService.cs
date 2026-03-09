using MYSTech.DTO.DTOs.BannerDTOs;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Business.Abstract
{
    public interface IBannerService
        : IGenericService<Banner, ResultBannerDto, CreateBannerDto, UpdateBannerDto>
    {
        Task<List<ResultBannerDto>> TGetActiveBannersAsync();
        Task<List<ResultBannerDto>> TGetOrderedBannersAsync();
    }
}
