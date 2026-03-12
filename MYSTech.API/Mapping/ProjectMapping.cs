using AutoMapper;
using MYSTech.DTO.DTOs.ProjectDTOs;
using MYSTech.Entity.Entities;

namespace MYSTech.API.Mapping
{
    public class ProjectMapping : Profile
    {
        public ProjectMapping()
        {
            CreateMap<Project, ResultProjectDto>();
            CreateMap<Project, ResultProjectDetailDto>();
            CreateMap<CreateProjectDto, Project>();
            CreateMap<UpdateProjectDto, Project>();
        }
    }
}
