using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllowmeChallenge.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(long id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        void Dispose();
    }
}
