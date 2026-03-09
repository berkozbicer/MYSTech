using AutoMapper;
using MYSTech.Business.Abstract;
using MYSTech.DataAccess.Abstract;
using MYSTech.DTO.DTOs.BannerDTOs;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Business.Concrete
{
    public class BannerManager : GenericManager<Banner, ResultBannerDto, CreateBannerDto, UpdateBannerDto>, IBannerService
    {
        private readonly IRepository<Banner> _bannerRepository;

        public BannerManager(IRepository<Banner> repository, IMapper mapper)
            : base(repository, mapper)
        {
            _bannerRepository = repository;
        }

        public async Task<List<ResultBannerDto>> TGetActiveBannersAsync()
        {
            var entities = await _bannerRepository.GetFilteredListAsync(x => x.IsActive);
            return _mapper.Map<List<ResultBannerDto>>(entities);
        }

        public async Task<List<ResultBannerDto>> TGetOrderedBannersAsync()
        {
            var entities = await _bannerRepository.GetFilteredListAsync(x => x.IsActive);
            return _mapper.Map<List<ResultBannerDto>>(entities.OrderBy(x => x.Order).ToList());
        }
    }
}
