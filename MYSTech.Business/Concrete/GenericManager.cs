using AutoMapper;
using MYSTech.Business.Abstract;
using MYSTech.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MYSTech.Business.Concrete
{
    public class GenericManager<TEntity, TResultDto, TCreateDto, TUpdateDto>
        : IGenericService<TEntity, TResultDto, TCreateDto, TUpdateDto>
        where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public GenericManager(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<TResultDto>> TGetListAsync()
        {
            var entities = await _repository.GetListAsync();
            return _mapper.Map<List<TResultDto>>(entities);
        }

        public async Task<TResultDto> TGetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TResultDto>(entity);
        }

        public async Task<TResultDto> TGetByFilterAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = await _repository.GetByFilterAsync(predicate);
            return _mapper.Map<TResultDto>(entity);
        }

        public async Task<List<TResultDto>> TGetFilteredListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = await _repository.GetFilteredListAsync(predicate);
            return _mapper.Map<List<TResultDto>>(entities);
        }

        public async Task TCreateAsync(TCreateDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            await _repository.CreateAsync(entity);
        }

        public async Task TUpdateAsync(TUpdateDto dto)
        {
            var idProperty = typeof(TUpdateDto).GetProperty("Id")
                  ?? typeof(TUpdateDto).GetProperty(typeof(TEntity).Name + "Id");

            if (idProperty == null) throw new InvalidOperationException($"{typeof(TUpdateDto).Name} içinde Id property'si bulunamadı.");

            var id = (int)idProperty.GetValue(dto)!;

            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new KeyNotFoundException("Kayıt bulunamadı.");

            _mapper.Map(dto, entity);
            await _repository.UpdateAsync(entity);
        }

        public async Task TDeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<int> TCountAsync()
        {
            return await _repository.CountAsync();
        }

        public async Task<int> TFilteredCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.FilteredCountAsync(predicate);
        }
    }
}
