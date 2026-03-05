using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MYSTech.Business.Abstract
{
    public interface IGenericService<T> where T : class
    {
        List<T> TGetList();

        T TGetByFilter(Expression<Func<T, bool>> predicate);

        T TGetById(int id);

        void TCreate(T entity);

        void TUpdate(T entity);

        void TDelete(int id);

        int TCount();

        int TFilteredCount(Expression<Func<T, bool>> predicate); // Filtrelenmiş kayıt sayısı alma metodu

        List<T> TGetFilteredList(Expression<Func<T, bool>> predicate); // Filtrelenmiş liste alma metodu
    }
}
