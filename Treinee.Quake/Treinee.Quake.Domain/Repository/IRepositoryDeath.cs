using System.Collections.Generic;
using Treinee.Quake.Domain.Entity;

namespace Treinee.Quake.Domain.Repository
{
    public interface IRepositoryDeath : IRepositoryBase<Death>
    {
        ICollection<Death> GetDeaths(string name);
    }
}
