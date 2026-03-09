using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DataAccess.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetWithSubCategoriesAsync(int categoryId);
    }
}
