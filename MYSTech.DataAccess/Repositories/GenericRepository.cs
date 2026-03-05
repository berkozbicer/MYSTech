using MYSTech.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MYSTech.DataAccess.Context;
using Microsoft.EntityFrameworkCore;


namespace MYSTech.DataAccess.Repositories
{
    public class GenericRepository<T>(MYSTechContext _context) : IRepository<T> where T : class
    {
        public DbSet<T> Table { get => _context.Set<T>(); } // Veritabanındaki ilgili tabloya erişim sağlayan DbSet

        public int Count()
        {
            return Table.Count();
        }

        public void Create(T entity)
        {
            Table.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Table.Find(id);
            if (entity != null)
            {
                Table.Remove(entity);
                _context.SaveChanges();
            }
        }

        public int FilteredCount(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(predicate).Count();
        }

        public List<T> GetList()
        {
            return Table.ToList();
        }

        public T GetByFilter(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(predicate).FirstOrDefault(); // Verilen filtreye uyan ilk kaydı döndürür, eğer yoksa null döner
        }

        public T GetById(int id)
        {
            return Table.Find(id);
        }

        public List<T> GetFilteredList(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(predicate).ToList(); // Verilen filtreye uyan tüm kayıtları liste olarak döndürür
        }

        public void Update(T entity)
        {
            Table.Update(entity);
            _context.SaveChanges();
        }
    }
}
