using System;
using System.Collections.Generic;
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

        public ICollection<Death> GetDeaths(string name)
        {
            throw new NotImplementedException();
        }
    }
}
