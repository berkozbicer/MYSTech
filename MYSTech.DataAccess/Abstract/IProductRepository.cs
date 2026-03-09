using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DataAccess.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetDetailAsync(int productId);
        Task<Product> GetDetailBySlugAsync(string slug);
    }
}
