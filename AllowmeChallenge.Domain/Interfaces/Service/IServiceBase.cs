using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllowmeChallenge.Domain.Interfaces.Service
{
    public interface IServiceBase<TEntity>: IDisposable where TEntity: class
    {
        Task AddAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(long id);
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
