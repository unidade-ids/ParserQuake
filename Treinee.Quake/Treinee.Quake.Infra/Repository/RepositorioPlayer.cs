using System.Linq;
using Treinee.Quake.Domain.Entity;
using Treinee.Quake.Domain.Repository;
using Treinee.Quake.Infra.Context;

namespace Treinee.Quake.Infra.Repository
{
    public class RepositorioPlayer : RepositoryBase<Player>, IRepositorioPlayer
    {
        public RepositorioPlayer(QuakeContext context)
            :base(context)
        {
        }

        public Player GetByName(string name) => this._context.Player.FirstOrDefault(p => p.Name.Contains(name));
        public bool TherePlayer(string name)
        {
            return _context.Player.Any(p => p.Name == name);
        }
    }
}
