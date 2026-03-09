using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DataAccess.Abstract
{
    public interface IBlogCategoryRepository : IRepository<BlogCategory>
    {
        Task<BlogCategory> GetWithBlogsAsync(int blogCategoryId);
    }
}
