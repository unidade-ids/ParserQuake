using System;
using System.Collections.Generic;
using System.Text;

namespace Treinee.Quake.Domain.Entity
{
    public class Player : BaseEntity
    {
        public Player(string name)
        {
            Killeds = new HashSet<Death>();
            Killers = new HashSet<Death>();

            this.Name = name;
        }

        protected Player()
        {
        }

        public string Name { get; private set; }
        public virtual GamePlayer GamePlayer { get; set; }
        public virtual ICollection<Death> Killeds { get; set; }
        public virtual ICollection<Death> Killers { get; set; }
    }
}
