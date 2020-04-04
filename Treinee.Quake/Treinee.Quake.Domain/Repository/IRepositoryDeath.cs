using System.Collections.Generic;
using System.Linq;
using Treinee.Quake.Domain.Entity;
using Treinee.Quake.Domain.ValuesObject;

namespace Treinee.Quake.Domain.Repository
{
    public interface IRepositoryDeath : IRepositoryBase<Death>
    {
        IList<Kills> GetDeaths(string name);
        IList<Kills> GetTenDeaths();
    }
}
