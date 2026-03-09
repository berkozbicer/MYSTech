using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MYSTech.Business.Abstract
{
    public interface IGenericService<TEntity, TResultDto, TCreateDto, TUpdateDto>
        where TEntity : class
    {
        Task<List<TResultDto>> TGetListAsync();
        Task<TResultDto> TGetByIdAsync(int id);
        Task<TResultDto> TGetByFilterAsync(Expression<Func<TEntity, bool>> predicate);
        Task<List<TResultDto>> TGetFilteredListAsync(Expression<Func<TEntity, bool>> predicate);
        Task TCreateAsync(TCreateDto dto);
        Task TUpdateAsync(TUpdateDto dto);
        Task TDeleteAsync(int id);
        Task<int> TCountAsync();
        Task<int> TFilteredCountAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
