using MYSTech.DTO.DTOs.SocialMediaDTOs;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Business.Abstract
{
    public interface ISocialMediaService
        : IGenericService<SocialMedia, ResultSocialMediaDto, CreateSocialMediaDto, UpdateSocialMediaDto>
    {
        Task<List<ResultSocialMediaDto>> TGetActiveAsync();
    }
}
