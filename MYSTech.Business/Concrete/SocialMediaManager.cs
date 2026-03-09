using AutoMapper;
using MYSTech.Business.Abstract;
using MYSTech.DataAccess.Abstract;
using MYSTech.DTO.DTOs.SocialMediaDTOs;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Business.Concrete
{
    public class SocialMediaManager : GenericManager<SocialMedia, ResultSocialMediaDto, CreateSocialMediaDto, UpdateSocialMediaDto>, ISocialMediaService
    {
        private readonly IRepository<SocialMedia> _socialMediaRepository;

        public SocialMediaManager(IRepository<SocialMedia> repository, IMapper mapper)
            : base(repository, mapper)
        {
            _socialMediaRepository = repository;
        }

        public async Task<List<ResultSocialMediaDto>> TGetActiveAsync()
        {
            var entities = await _socialMediaRepository.GetFilteredListAsync(x => x.IsActive);
            return _mapper.Map<List<ResultSocialMediaDto>>(entities);
        }
    }
}
