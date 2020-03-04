using System.Threading.Tasks;
using Treinee.Quake.Domain.Entity;

namespace Treinee.Quake.Domain.Repository
{
    public interface IRepositorioPlayer : IRepositoryBase<Player>
    {
        bool TherePlayer(string name);
        Player GetByName(string name);
    }
}
