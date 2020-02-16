using System;
using System.Collections.Generic;
using System.Text;

namespace Treinee.Quake.Domain.Entity
{
    public class Player : BaseEntity
    {
        public Player()
        {
            Killeds     = new HashSet<Death>();
            Killers     = new HashSet<Death>();
            GamePlayers = new HashSet<GamePlayer>();
        }

        public string Name { get; set; }
        public DateTime DataRegister { get; set; }
        public virtual GamePlayer GamePlayer { get; set; }
        public virtual ICollection<Death> Killeds { get; set; }
        public virtual ICollection<Death> Killers { get; set; }
        public virtual ICollection<GamePlayer> GamePlayers { get; set; }
    }
}
