using System;
using System.Collections.Generic;
using System.Text;

namespace Treinee.Quake.Domain.Entity
{
    public class Game : BaseEntity
    {
        public Game(DateTime? dataRegister)
        {
            Deaths            = new HashSet<Death>();
            GamePlayers       = new HashSet<GamePlayer>();

            this.DateRegister = dataRegister;
        }

        protected Game()
        { 
        }

        public DateTime? DateRegister { get; private set; }
        public virtual ICollection<GamePlayer> GamePlayers { get; set; }
        public virtual ICollection<Death> Deaths { get; set; }
    }
}
