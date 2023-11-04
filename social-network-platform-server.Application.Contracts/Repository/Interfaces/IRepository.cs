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
        Task<List<TEntity>> AddRangeAsync(List<TEntity> entitys);
        Task<TEntity> GetByIdAsync(Guid Id);
        Task<List<TEntity>> GetAsync(Guid Id);
        Task<bool> DeleteAsync(Guid Id, bool isSoft);
    }
}
