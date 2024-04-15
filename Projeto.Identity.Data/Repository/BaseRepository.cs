using Microsoft.EntityFrameworkCore;
using Projeto.Identity.Data.Context;
using Projeto.Identity.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Identity.Data.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly DataContext dataContext;

        public BaseRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task CreateAsync(TEntity obj)
        {
            await dataContext.AddAsync(obj);
            await dataContext.SaveChangesAsync();
        }

        public Task DeleteAsync(TEntity obj)
        {
            dataContext.Remove(obj);
            dataContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task UpdateAsync(TEntity obj)
        {
            dataContext.Update(obj);
            dataContext.SaveChanges();
            return Task.CompletedTask;
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await dataContext.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where)
        {
            return await dataContext.Set<TEntity>().Where(where).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where)
        {
            return await dataContext.Set<TEntity>().FirstOrDefaultAsync(where);
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await dataContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<bool> AnyAsync()
        {
            return await dataContext.Set<TEntity>().AnyAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> where)
        {
            return await dataContext.Set<TEntity>().AnyAsync(where);
        }
    }
}
