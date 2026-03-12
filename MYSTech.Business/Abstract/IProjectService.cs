using MYSTech.DTO.DTOs.ProjectDTOs;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MYSTech.Business.Abstract
{
    public interface IProjectService : IGenericService<Project, ResultProjectDto, CreateProjectDto, UpdateProjectDto>
    {
        Task<ResultProjectDetailDto> TGetDetailAsync(int id);
        Task<ResultProjectDetailDto> TGetDetailBySlugAsync(string slug);
        Task<List<ResultProjectDto>> TGetActiveProjectsAsync();
        Task<List<ResultProjectDto>> TGetOrderedProjectsAsync();
        Task<List<ResultProjectDto>> TGetByCategoryAsync(string category);
    }
}
