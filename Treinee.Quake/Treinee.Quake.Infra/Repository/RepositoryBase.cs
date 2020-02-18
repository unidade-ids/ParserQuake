using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Treinee.Quake.Domain.Entity;
using Treinee.Quake.Domain.Repository;
using Treinee.Quake.Infra.Context;


namespace Treinee.Quake.Infra.Repository
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        private readonly QuakeContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public RepositoryBase(QuakeContext context)
        {
            _context = context;
            _dbSet   = _context.Set<TEntity>();
            
        }
        public async Task Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public Task Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(int id) => await _dbSet.FindAsync(id);

        public virtual async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public virtual Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
