using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Treinee.Quake.Domain.Entity;

namespace Treinee.Quake.Domain.Repository
{
    public interface IRepositoryBase<TEntity>  where TEntity : BaseEntity
    {
        Task Add(TEntity entity);
        Task Save();
        Task Delete(int id);
        Task Update(TEntity entity);
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate);
    }
}
