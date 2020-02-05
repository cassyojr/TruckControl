using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Repository
{
    public interface IGenericRepositoryAsync<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> GetByIdAsync(object id);
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> AddAsync(TEntity obj);
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        TEntity Update(TEntity obj);
        void UpdateRange(IEnumerable<TEntity> entities);

        Task RemoveAsync(object id);
        TEntity Remove(TEntity obj);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
