using System.Threading.Tasks;
using Treinee.Quake.Domain.Entity;
using Treinee.Quake.Domain.Repository;

namespace Treinee.Quake.Domain.Core
{
    public class ManagerGamePlayer
    {
        private readonly IRepositorioGamePlayer _repositoryGamePlayer;
        private readonly IUnitOfWork _unitOfWork;

        public Game Game { get; set; }
        public Player Player { get; set; }
        public GamePlayer GamePlayer { get; set; }
        public ManagerGamePlayer(IRepositorioGamePlayer repositoryGamePlayer, IUnitOfWork unitOfWork)
        {
            _repositoryGamePlayer = repositoryGamePlayer;
            _unitOfWork = unitOfWork;
        }

        public ManagerGamePlayer(Game game, Player player, IRepositorioGamePlayer repositoryGamePlayer, IUnitOfWork unitOfWork)
        {
            this.Game             = game;
            this.Player           = player;
            _repositoryGamePlayer = repositoryGamePlayer;
            _unitOfWork           = unitOfWork;
        }

        public async Task Save()
        {
            try
            {
                if (this.Game != null && this.Player != null)
                {
                    if (!_repositoryGamePlayer.ThereGamePlayer(Game.ID, Player.ID))
                    {
                        this.GamePlayer = new GamePlayer(this.Game, this.Player);

                        await _repositoryGamePlayer.Add(GamePlayer);
                        await _unitOfWork.Save();
                    }
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
