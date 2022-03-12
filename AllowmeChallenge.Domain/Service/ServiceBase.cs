using AllowmeChallenge.Domain.Interfaces.Repository;
using AllowmeChallenge.Domain.Interfaces.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllowmeChallenge.Domain.Service
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;
        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repositoryBase = repository;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _repositoryBase.AddAsync(entity);
        }

        public void Dispose()
        {
            _repositoryBase.Dispose();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repositoryBase.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await _repositoryBase.GetByIdAsync(id);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            await _repositoryBase.RemoveAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _repositoryBase.UpdateAsync(entity);
        }
    }
}
