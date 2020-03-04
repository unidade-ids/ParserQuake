using System.Text.RegularExpressions;
using Treinee.Quake.Domain.Entity;
using Treinee.Quake.Domain.Repository;

namespace Treinee.Quake.Domain.Core
{
    public class ManagerPlayer
    {
        private readonly IRepositorioPlayer _repositoryPlayer;
        private readonly IUnitOfWork _unitOfWork;
        public Player Player { get; private set; }
        public string Row { get; set; }

        public ManagerPlayer(IRepositorioPlayer repositoryPlayer, IUnitOfWork unitOfWork)
        {
            _repositoryPlayer = repositoryPlayer;
            _unitOfWork       = unitOfWork;
        }
        public ManagerPlayer(string row)
        {
            this.Row = row;
        }

        public Player Save()
        {
            if (!string.IsNullOrEmpty(this.Row))
            {
                var name    = Regex.Match(this.Row, @"n\\(.+?)\\t").Groups[1].ToString().Trim();
                this.Player = new Player(name);

                if (!_repositoryPlayer.TherePlayer(name))
                {
                    _repositoryPlayer.Add(this.Player);
                    _unitOfWork.Save();

                    return this.Player;
                }
            }

            return null;
        }
    }
}
