using Microsoft.EntityFrameworkCore;
using MYSTech.DataAccess.Abstract;
using MYSTech.DataAccess.Context;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DataAccess.Repositories
{
    public class BlogCategoryRepository : GenericRepository<BlogCategory>, IBlogCategoryRepository
    {
        private readonly MYSTechContext _context;

        public BlogCategoryRepository(MYSTechContext context) : base(context)
        {
            _context = context;
        }

        public async Task<BlogCategory> GetWithBlogsAsync(int blogCategoryId)
        {
            return await _context.BlogCategories
                .Include(bc => bc.Blogs)
                .FirstOrDefaultAsync(bc => bc.BlogCategoryId == blogCategoryId);
        }
    }
}
