using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Treinee.Quake.Domain.Entity;
using Treinee.Quake.Domain.Repository;
using Treinee.Quake.Domain.ValuesObject;
using Treinee.Quake.Infra.Context;

namespace Treinee.Quake.Infra.Repository
{
    public class RepositoryDeath : RepositoryBase<Death>, IRepositoryDeath
    {
        public RepositoryDeath(QuakeContext context)
            : base(context)
        {
        }

        public IList<Kills> GetDeaths(string name)
        {
            var deaths = this._context.Death.Include(k => k.Killer)
                             .Where(k => k.Killer.Name.Equals(name) && !k.Killer.Name.Equals("<world>"))
                             .GroupBy(dd => dd.Killer.Name)
                             .Select(g => new Kills
                             {
                                Nome = g.Key,
                                Quantidade = g.Count()
                             }).ToList();

            return deaths;
        }

        public IList<Kills> GetTenDeaths()
        {
            var deaths = this._context.Death.Include(k => k.Killer)
                .Where(k => !k.Killer.Name.Equals("<world>"))
                .GroupBy(dd => dd.Killer.Name)
                .Select(g => new Kills
                {
                    Nome = g.Key,
                    Quantidade = g.Count()
                }).ToList();

            return deaths;
        }
    }
}
