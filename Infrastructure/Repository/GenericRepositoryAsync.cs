using Infrastructure.Interfaces.Repository;
using Infrastructure.Repository.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class GenericRepositoryAsync<TEntity> : IGenericRepositoryAsync<TEntity> where TEntity : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly DbSet<TEntity> DbSet;

        protected GenericRepositoryAsync(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            DbSet = _unitOfWork.Context.Set<TEntity>();
        }

        public virtual async Task<TEntity> AddAsync(TEntity obj)
        {
            var entryEntity = await DbSet.AddAsync(obj);
            return entryEntity.Entity;
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await DbSet.AddRangeAsync(entities);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task RemoveAsync(object id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null) return;

            Remove(entity);
        }

        public virtual TEntity Remove(TEntity obj)
        {
            DbSet.Remove(obj);
            return obj;
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
        }

        public virtual TEntity Update(TEntity obj)
        {
            _unitOfWork.Context.Entry(obj).State = EntityState.Modified;
            return obj;
        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            DbSet.UpdateRange(entities);
        }

        public void Dispose()
        {
            _unitOfWork.Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
