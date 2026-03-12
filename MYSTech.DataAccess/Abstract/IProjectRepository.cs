using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DataAccess.Abstract
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<List<Project>> GetActiveProjectsAsync();
        Task<List<Project>> GetOrderedProjectsAsync();
        Task<Project> GetBySlugAsync(string slug);
        Task<List<Project>> GetByCategoryAsync(string category);
    }
}
