using Treinee.Quake.Domain.Entity;

namespace Treinee.Quake.Domain.Repository
{
    public interface IRepositorioGamePlayer : IRepositoryBase<GamePlayer>
    {
        bool ThereGamePlayer(int idGame, int idPlayer);
    }
}
