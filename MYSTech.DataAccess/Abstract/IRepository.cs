using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MYSTech.DataAccess.Abstract
{
    public interface IRepository<T> where T : class
    {
        List<T> GetList();

        T GetByFilter(Expression<Func<T, bool>> predicate);

        T GetById(int id);

        void Create(T entity);

        void Update(T entity);

        void Delete(int id);

        int Count();

        int FilteredCount(Expression<Func<T, bool>> predicate); // Filtrelenmiş kayıt sayısı alma metodu

        List<T> GetFilteredList(Expression<Func<T, bool>> predicate); // Filtrelenmiş liste alma metodu
    }
}
