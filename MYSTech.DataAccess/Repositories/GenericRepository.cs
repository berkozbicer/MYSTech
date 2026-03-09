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
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly MYSTechContext _context;
        public DbSet<T> Table => _context.Set<T>();

        public GenericRepository(MYSTechContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetListAsync()
            => await Table.ToListAsync();

        public async Task<T> GetByIdAsync(int id)
            => await Table.FindAsync(id);

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> predicate)
            => await Table.Where(predicate).FirstOrDefaultAsync();

        public async Task<List<T>> GetFilteredListAsync(Expression<Func<T, bool>> predicate)
            => await Table.Where(predicate).ToListAsync();

        public async Task CreateAsync(T entity)
        {
            await Table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            Table.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await Table.FindAsync(id);
            if (entity != null)
            {
                Table.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> CountAsync()
            => await Table.CountAsync();

        public async Task<int> FilteredCountAsync(Expression<Func<T, bool>> predicate)
            => await Table.Where(predicate).CountAsync();
    }
}
