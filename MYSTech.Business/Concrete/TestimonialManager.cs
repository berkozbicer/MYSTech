using AutoMapper;
using MYSTech.Business.Abstract;
using MYSTech.DataAccess.Abstract;
using MYSTech.DTO.DTOs.TestimonialDTOs;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Business.Concrete
{
    public class TestimonialManager : GenericManager<Testimonial, ResultTestimonialDto, CreateTestimonialDto, UpdateTestimonialDto>, ITestimonialService
    {
        private readonly IRepository<Testimonial> _testimonialRepository;

        public TestimonialManager(IRepository<Testimonial> repository, IMapper mapper)
            : base(repository, mapper)
        {
            _testimonialRepository = repository;
        }

        public async Task<List<ResultTestimonialDto>> TGetActiveAsync()
        {
            var entities = await _testimonialRepository.GetFilteredListAsync(x => x.IsActive);
            return _mapper.Map<List<ResultTestimonialDto>>(entities);
        }
    }
}
