using Microsoft.EntityFrameworkCore;
using MYSTech.DataAccess.Abstract;
using MYSTech.DataAccess.Context;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DataAccess.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        private readonly MYSTechContext _context;

        public ProjectRepository(MYSTechContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Project>> GetActiveProjectsAsync()
        {
            return await _context.Projects
                .Where(x => x.IsActive)
                .OrderBy(x => x.Order)
                .ToListAsync();
        }

        public async Task<List<Project>> GetOrderedProjectsAsync()
        {
            return await _context.Projects
                .OrderBy(x => x.Order)
                .ToListAsync();
        }

        public async Task<Project> GetBySlugAsync(string slug)
        {
            return await _context.Projects
                .FirstOrDefaultAsync(x => x.Slug == slug);
        }

        public async Task<List<Project>> GetByCategoryAsync(string category)
        {
            return await _context.Projects
                .Where(x => x.Category == category && x.IsActive)
                .OrderBy(x => x.Order)
                .ToListAsync();
        }
    }
}
