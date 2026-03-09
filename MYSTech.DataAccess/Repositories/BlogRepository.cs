using Microsoft.EntityFrameworkCore;
using MYSTech.DataAccess.Abstract;
using MYSTech.DataAccess.Context;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DataAccess.Repositories
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        private readonly MYSTechContext _context;

        public BlogRepository(MYSTechContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Blog> GetDetailAsync(int blogId)
        {
            return await _context.Blogs
                .Include(b => b.BlogCategory)
                .FirstOrDefaultAsync(b => b.BlogId == blogId);
        }

        public async Task<Blog> GetDetailBySlugAsync(string slug)
        {
            return await _context.Blogs
                .Include(b => b.BlogCategory)
                .FirstOrDefaultAsync(b => b.Slug == slug);
        }
    }
}
