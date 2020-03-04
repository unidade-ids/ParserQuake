using Treinee.Quake.Domain.Entity;
using Treinee.Quake.Domain.Repository;

namespace Treinee.Quake.Domain.Core
{
    public class ManagerGame
    {
        private readonly IRepositoryBase<Game> _repositoryGame;
        private readonly IUnitOfWork _unitOfWork;
        public Game Game { get; set; }
        public string Row { get; private set; }
        public ManagerGame(IRepositoryBase<Game> repositoryGame, IUnitOfWork unitOfWork)
        {
            _repositoryGame = repositoryGame;
            _unitOfWork     = unitOfWork;
        }

        public ManagerGame(string row)
        {
            this.Row = row;
        }

        public Game Save()
        {
            if (!string.IsNullOrEmpty(this.Row))
            {
                this.Game = new Game(null);
                _repositoryGame.Add(this.Game);

                _unitOfWork.Save();

                return this.Game;
            }

            return null;
        }
    }
}
