using Microsoft.EntityFrameworkCore;
using MYSTech.DataAccess.Abstract;
using MYSTech.DataAccess.Context;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DataAccess.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly MYSTechContext _context;

        public CategoryRepository(MYSTechContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Category> GetWithSubCategoriesAsync(int categoryId)
        {
            return await _context.Categories
                .Include(c => c.SubCategories)
                .Include(c => c.ParentCategory)
                .FirstOrDefaultAsync(c => c.CategoryId == categoryId);
        }
    }
}
