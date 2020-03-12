using System;
using System.Collections.Generic;
using System.Text;

namespace Treinee.Quake.Domain.Entity
{
    public class Player : BaseEntity
    {
        public Player(string name)
        {
            KillerDeaths = new HashSet<Death>();
            KilledDeaths = new HashSet<Death>();
            GamePlayers  = new HashSet<GamePlayer>();
            this.Name    = name;
            this.DataRegister = DateTime.Now;
        }

        protected Player()
        {
        }

        public string Name { get; private set; }
        public DateTime DataRegister { get; set; }
        public virtual ICollection<GamePlayer> GamePlayers { get; set; }
        public virtual ICollection<Death> KillerDeaths { get; set; }
        public virtual ICollection<Death> KilledDeaths { get; set; }
    }
}
