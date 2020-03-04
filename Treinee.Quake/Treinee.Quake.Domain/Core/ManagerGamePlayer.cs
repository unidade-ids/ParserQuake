using Treinee.Quake.Domain.Entity;
using Treinee.Quake.Domain.Repository;

namespace Treinee.Quake.Domain.Core
{
    public class ManagerGamePlayer
    {
        private readonly IRepositoryBase<GamePlayer> _repositoryGamePlayer;
        private readonly IUnitOfWork _unitOfWork;

        public Game Game { get; set; }
        public Player Player { get; set; }
        public GamePlayer GamePlayer { get; set; }
        public ManagerGamePlayer(IRepositoryBase<GamePlayer> repositoryGamePlayer, IUnitOfWork unitOfWork)
        {
            _repositoryGamePlayer = repositoryGamePlayer;
            _unitOfWork = unitOfWork;
        }

        public ManagerGamePlayer(Game game, Player player)
        {
            this.Game   = game;
            this.Player = player;
        }

        public void Save()
        {
            if (this.Game != null && this.Player != null)
            {
                this.GamePlayer = new GamePlayer(this.Game, this.Player);

                _repositoryGamePlayer.Add(GamePlayer);
                _unitOfWork.Save();
            }
        }
    }
}
