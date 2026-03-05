using MYSTech.Business.Abstract;
using MYSTech.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MYSTech.Business.Concrete
{
    public class GenericManager<T>(IRepository<T> _repository) : IGenericService<T> where T : class
    {
        public int TCount()
        {
            return _repository.Count();
        }

        public void TCreate(T entity)
        {
            _repository.Create(entity);
        }

        public void TDelete(int id)
        {
            _repository.Delete(id);
        }

        public int TFilteredCount(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _repository.FilteredCount(predicate);
        }

        public List<T> TGetAll()
        {
            return _repository.GetList();
        }

        public T TGetByFilter(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _repository.GetByFilter(predicate);
        }

        public T TGetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<T> TGetFilteredList(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _repository.GetFilteredList(predicate);
        }

        public List<T> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(T entity)
        {
            _repository.Update(entity);
        }
    }
}
