using System.Collections.Generic;
using System.Linq;
using Treinee.Quake.Domain.Entity;

namespace Treinee.Quake.Domain.Repository
{
    public interface IRepositoryDeath : IRepositoryBase<Death>
    {
        IQueryable<Death> GetDeaths(string name);
        IQueryable<Death> GetTenDeaths();
    }
}
