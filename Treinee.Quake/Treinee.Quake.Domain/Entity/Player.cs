using System;
using System.Collections.Generic;
using System.Text;

namespace Treinee.Quake.Domain.Entity
{
    public class Player : BaseEntity
    {
        public Player(string name, DateTime dataRegister)
        {
            Killeds = new HashSet<Death>();
            Killers = new HashSet<Death>();

            this.Name         = name;
            this.DataRegister = dataRegister;
        }

        public string Name { get; private set; }
        public DateTime DataRegister { get; private set; }
        public virtual GamePlayer GamePlayer { get; set; }
        public virtual ICollection<Death> Killeds { get; set; }
        public virtual ICollection<Death> Killers { get; set; }
    }
}
