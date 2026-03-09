using AutoMapper;
using MYSTech.DTO.DTOs.TestimonialDTOs;
using MYSTech.Entity.Entities;

namespace MYSTech.API.Mapping
{
    public class TestimonialMapping : Profile
    {
        public TestimonialMapping() 
        {
            CreateMap<Testimonial, ResultTestimonialDto>();
            CreateMap<CreateTestimonialDto, Testimonial>();
            CreateMap<UpdateTestimonialDto, Testimonial>();
        }
    }
}
