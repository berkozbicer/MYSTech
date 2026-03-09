using Microsoft.EntityFrameworkCore;
using MYSTech.DataAccess.Abstract;
using MYSTech.DataAccess.Context;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DataAccess.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly MYSTechContext _context;

        public ProductRepository(MYSTechContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Product> GetDetailAsync(int productId)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .Include(p => p.ProductFeatures)
                .FirstOrDefaultAsync(p => p.ProductId == productId);
        }

        public async Task<Product> GetDetailBySlugAsync(string slug)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .Include(p => p.ProductFeatures)
                .FirstOrDefaultAsync(p => p.Slug == slug);
        }
    }
}
