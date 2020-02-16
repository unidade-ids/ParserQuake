using System;
using System.Collections.Generic;
using System.Text;

namespace Treinee.Quake.Domain.Entity
{
    public class GamePlayer
    {
        public int IdGame { get; set; }
        public int IdPlayer { get; set; }

        public virtual Game Game { get; set; }
        public virtual Player Player { get; set; }
    }
}
