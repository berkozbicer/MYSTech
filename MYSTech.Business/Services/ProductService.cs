using MYSTech.DataAccess.UnitOfWork;
using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Business.Services
{
    public class ProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<Product>> GetHomeProductsAsync()
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            return products.Where(p => p.IsHomeShown);
        }

        public async Task<Product> GetProductByIdAsync(int id) => await _unitOfWork.Products.GetByIdAsync(id);

        public async Task AddProductAsync(Product product)
        {
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
