using AutoMapper;
using MYSTech.Business.Abstract;
using MYSTech.DataAccess.Abstract;
using MYSTech.DTO.DTOs.AboutDTOs;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Business.Concrete
{
    public class AboutManager : GenericManager<About, ResultAboutDto, CreateAboutDto, UpdateAboutDto>, IAboutService
    {
        private readonly IRepository<About> _aboutRepository;

        public AboutManager(IRepository<About> repository, IMapper mapper)
            : base(repository, mapper)
        {
            _aboutRepository = repository;
        }

        public async Task<ResultAboutDto> TGetFirstAsync()
        {
            var entity = await _aboutRepository.GetByFilterAsync(x => !x.IsDeleted);
            return _mapper.Map<ResultAboutDto>(entity);
        }
    }
}
