using System;
using System.Collections.Generic;
using System.Text;

namespace Treinee.Quake.Domain.Entity
{
    public class GamePlayer
    {
        public GamePlayer(Game game, Player player)
        {
            this.Game   = game;
            this.Player = player;
        }

        protected GamePlayer()
        { 
        }

        public int IdGame { get; set; }
        public int IdPlayer { get; set; }

        public virtual Game Game { get; private set; }
        public virtual Player Player { get; private set; }
    }
}
