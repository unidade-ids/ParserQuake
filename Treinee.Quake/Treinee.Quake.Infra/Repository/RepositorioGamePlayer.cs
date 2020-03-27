using System;
using System.Linq;
using Treinee.Quake.Domain.Entity;
using Treinee.Quake.Domain.Repository;
using Treinee.Quake.Infra.Context;

namespace Treinee.Quake.Infra.Repository
{
    public class RepositorioGamePlayer : RepositoryBase<GamePlayer>, IRepositorioGamePlayer
    {
        public RepositorioGamePlayer(QuakeContext context)
            :base(context)
        {
        }
        public bool ThereGamePlayer(int idGame, int idPlayer)
        {
            return _context.GamePlayer.Any(gp => gp.IdGame == idGame && gp.IdPlayer == idPlayer);
        }
    }
}
