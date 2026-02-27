using MYSTech.DataAccess.Context;
using MYSTech.DataAccess.Repositories;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DataAccess.UnitOfWork
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly MYSTechContext _context;

        public EfUnitOfWork(MYSTechContext context)
        {
            _context = context;
            Products = new EfRepository<Product>(_context);
            Categories = new EfRepository<Category>(_context);
            ProductImages = new EfRepository<ProductImage>(_context);
            ProductFeatures = new EfRepository<ProductFeature>(_context);
            Banners = new EfRepository<Banner>(_context);
        }

        public IRepository<Product> Products { get; private set; }
        public IRepository<Category> Categories { get; private set; }
        public IRepository<ProductImage> ProductImages { get; private set; }
        public IRepository<ProductFeature> ProductFeatures { get; private set; }
        public IRepository<Banner> Banners { get; private set; }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
