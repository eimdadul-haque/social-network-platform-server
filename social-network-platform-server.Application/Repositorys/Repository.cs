using social_network_platform_server.Application.Contracts.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace social_network_platform_server.Application.Repositorys
{
    public class Repository<TEntity> where TEntity : class, IRepository<TEntity>
    {
        public Task<TEntity> AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> AddRangeAsync(List<TEntity> entitys)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid Id, bool isSoft)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
