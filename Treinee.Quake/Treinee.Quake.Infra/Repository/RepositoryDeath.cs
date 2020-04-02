using System.Collections.Generic;
using System.Linq;
using Treinee.Quake.Domain.Entity;
using Treinee.Quake.Domain.Repository;
using Treinee.Quake.Infra.Context;

namespace Treinee.Quake.Infra.Repository
{
    public class RepositoryDeath : RepositoryBase<Death>, IRepositoryDeath
    {
        public RepositoryDeath(QuakeContext context)
            : base(context)
        {
        }

        public IQueryable<Death> GetDeaths(string name)
        {
            return this._context.Death.Take(10);
        }

        public IQueryable<Death> GetTenDeaths()
        {
            return this._context.Death.Take(10);
        }
    }
}
