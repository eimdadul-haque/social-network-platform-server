using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace social_network_platform_server.Application.Contracts.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class 
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<List<TEntity>> AddRangeAsync(List<TEntity> entities);
        Task<TEntity> GetByIdAsync(Guid Id);
        Task<List<TEntity>> GetAllAsync();
        Task<bool> DeleteAsync(Guid Id);
        Task<int> SaveChangeAsync();
        IQueryable<TEntity> GetQueryable();
    }
}
