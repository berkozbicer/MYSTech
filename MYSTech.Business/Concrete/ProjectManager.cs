using AutoMapper;
using MYSTech.Business.Abstract;
using MYSTech.DataAccess.Abstract;
using MYSTech.DTO.DTOs.ProjectDTOs;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Business.Concrete
{
    public class ProjectManager : GenericManager<Project, ResultProjectDto, CreateProjectDto, UpdateProjectDto>, IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectManager(
            IProjectRepository projectRepository,
            IMapper mapper) : base(projectRepository, mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<ResultProjectDetailDto> TGetDetailAsync(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            return _mapper.Map<ResultProjectDetailDto>(project);
        }

        public async Task<ResultProjectDetailDto> TGetDetailBySlugAsync(string slug)
        {
            var project = await _projectRepository.GetBySlugAsync(slug);
            return _mapper.Map<ResultProjectDetailDto>(project);
        }

        public async Task<List<ResultProjectDto>> TGetActiveProjectsAsync()
        {
            var projects = await _projectRepository.GetActiveProjectsAsync();
            return _mapper.Map<List<ResultProjectDto>>(projects);
        }

        public async Task<List<ResultProjectDto>> TGetOrderedProjectsAsync()
        {
            var projects = await _projectRepository.GetOrderedProjectsAsync();
            return _mapper.Map<List<ResultProjectDto>>(projects);
        }

        public async Task<List<ResultProjectDto>> TGetByCategoryAsync(string category)
        {
            var projects = await _projectRepository.GetByCategoryAsync(category);
            return _mapper.Map<List<ResultProjectDto>>(projects);
        }
    }
}
