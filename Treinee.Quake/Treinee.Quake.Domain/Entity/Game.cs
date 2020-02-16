using System;
using System.Collections.Generic;
using System.Text;

namespace Treinee.Quake.Domain.Entity
{
    public class Game : BaseEntity
    {
        public Game()
        {
            Deaths      = new HashSet<Death>();
            GamePlayers = new HashSet<GamePlayer>();
        }
        public DateTime? DateRegister { get; set; }
        public virtual ICollection<GamePlayer> GamePlayers { get; set; }
        public virtual ICollection<Death> Deaths { get; set; }
    }
}
