using System.Threading.Tasks;
using Treinee.Quake.Domain.Entity;
using Treinee.Quake.Domain.Repository;

namespace Treinee.Quake.Domain.Core
{
    public class ManagerGame
    {
        private readonly IRepositoryBase<Game> _repositoryGame;
        private readonly IUnitOfWork _unit;
        public Game Game { get; set; }
        public string Row { get; private set; }
        
        public ManagerGame(string row, IRepositoryBase<Game> repositoryGame, IUnitOfWork unit)
        {
            this.Row        = row;
            _repositoryGame = repositoryGame;
            _unit           = unit;
        }

        public async Task<Game> Save()
        {
            if (!string.IsNullOrEmpty(this.Row))
            {
                this.Game = new Game(null);
                await _repositoryGame.Add(this.Game);
                await _unit.Save();

                return this.Game;
            }

            return null;
        }
    }
}
