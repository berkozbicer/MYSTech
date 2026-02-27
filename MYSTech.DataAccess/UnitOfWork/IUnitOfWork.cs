using MYSTech.DataAccess.Repositories;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }
        IRepository<Category> Categories { get; }
        IRepository<ProductImage> ProductImages { get; }
        IRepository<ProductFeature> ProductFeatures { get; }
        IRepository<Banner> Banners { get; }
        Task SaveChangesAsync();
    }
}
