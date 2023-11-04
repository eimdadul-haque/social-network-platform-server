using Microsoft.EntityFrameworkCore;
using social_network_platform_server.Application.Contracts.Repository.Interfaces;
using social_network_platform_server.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace social_network_platform_server.Application.Repositorys
{
    public class Repository<TEntity> where TEntity : class, IRepository<TEntity>
    {
        private readonly ApplicationDbContext _dbContext;
        public Repository(
            ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>()
                .AddAsync(entity);

            if (await SaveChangeAsync() > 0)
                return entity;

            throw new Exception("Entity not added.");
        }

        public async Task<List<TEntity>> AddRangeAsync(List<TEntity> entities)
        {
            await _dbContext.Set<TEntity>()
                .AddRangeAsync(entities);
            if (await SaveChangeAsync() > 0) return entities;
            throw new Exception("Entity not added.");
        }

        public async Task<TEntity?> GetByIdAsync(Guid Id)
            => await _dbContext.Set<TEntity>().FindAsync(Id);

        public async Task<List<TEntity>> GetAllAsync()
            => await _dbContext.Set<TEntity>().ToListAsync();

        public async Task<bool> DeleteAsync(Guid Id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(Id);
            if (entity is null) throw new Exception("Entity not found.");
            _dbContext.Set<TEntity>().Remove(entity);
            return await SaveChangeAsync() > 0;
        }

        public async Task<bool> DeleteRangeAsync(List<Guid> Ids)
        {
            var entitys = await _dbContext.Set<TEntity>()
                .Where(entity => Ids.Contains((Guid) entity.GetType().GetProperty("Id").GetValue(entity)))
                .ToListAsync();
            if (entitys.Count <= 0)
                throw new Exception("Entity not found.");
            _dbContext.Set<TEntity>().RemoveRange(entitys);
            return await SaveChangeAsync() > 0;
        }

        public IQueryable<TEntity> GetQueryable()
            => _dbContext.Set<TEntity>().AsQueryable();

        public async Task<int> SaveChangeAsync()
            => await _dbContext.SaveChangesAsync();
    }
}




