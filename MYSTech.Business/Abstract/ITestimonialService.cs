using MYSTech.DTO.DTOs.TestimonialDTOs;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Business.Abstract
{
    public interface ITestimonialService
        : IGenericService<Testimonial, ResultTestimonialDto, CreateTestimonialDto, UpdateTestimonialDto>
    {
        Task<List<ResultTestimonialDto>> TGetActiveAsync();
    }
}
