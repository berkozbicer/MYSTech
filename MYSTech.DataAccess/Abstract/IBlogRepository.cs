using MYSTech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.DataAccess.Abstract
{
    public interface IBlogRepository : IRepository<Blog>
    {
        Task<Blog> GetDetailAsync(int blogId);
        Task<Blog> GetDetailBySlugAsync(string slug);
    }
}
