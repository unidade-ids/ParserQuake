using System.Text.RegularExpressions;
using Treinee.Quake.Domain.Entity;
using Treinee.Quake.Domain.Enum;
using Treinee.Quake.Domain.Extensions;
using Treinee.Quake.Domain.Repository;

namespace Treinee.Quake.Domain.Core
{
    public class ManagerDeath
    {
        public Death Death { get; private set; }
        public Game Game { get; private set; }
        public Player Player { get; private set; }
        public Player Killer { get; private set; }
        public Player Killed { get; private set; }
        public Armor Armor { get; private set; }
        public string Row { get; private set; }

        private readonly IRepositoryBase<Game> _repositoryGame;
        private readonly IRepositoryBase<GamePlayer> _repositoryGamePlayer;
        private readonly IRepositoryBase<Armor> _repositoryArmor;
        private readonly IRepositoryBase<Death> _repositoryDeath;
        private readonly IRepositorioPlayer _repositoryPlayer;
        private readonly IUnitOfWork _unitOfWork;
        public ManagerDeath(IRepositoryBase<Game> repositoryGame, IRepositoryBase<GamePlayer> repositoryGamePlayer, IRepositorioPlayer repositoryPlayer, IUnitOfWork unitOfWork)
        {
            _repositoryGame       = repositoryGame;
            _repositoryGamePlayer = repositoryGamePlayer;
            _repositoryPlayer     = repositoryPlayer;
            _unitOfWork           = unitOfWork;
        }
        public ManagerDeath(string row)
        {
            this.Row = row;
        }

        public async void Save()
        {
            if (!string.IsNullOrEmpty(this.Row))
            {
                var killed = Regex.Match(Row, @"killed (.+?)by").Groups[1].ToString().Trim();
                var index  = Row.Substring(Row.LastIndexOf(":")).Replace(":", string.Empty).Trim();
                var killer = index.Before("killed").Trim();
                var armor  = Row.Substring(Row.LastIndexOf(" by ") + 1).Replace("by", string.Empty).Trim();

                this.Killed = await _repositoryPlayer.GetByName(killed);
                this.Killer = await _repositoryPlayer.GetByName(killer);

                var idArmor = (DeathEnum)System.Enum.Parse(typeof(DeathEnum), armor);

                this.Armor = await _repositoryArmor.GetById((short)idArmor);

                this.Death = new Death(Killer, Killed, Game, Armor);

                await _repositoryDeath.Add(Death);
                await _unitOfWork.Save();
            }
        }
    }
}
