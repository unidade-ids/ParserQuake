using System;
using System.Collections.Generic;
using System.Text;
using Treinee.Quake.Domain.Enum;

namespace Treinee.Quake.Domain.Entity
{
    public class Death : BaseEntity
    {
        public int IdKiller { get; set; }
        public virtual Player Killer { get; set; }
        public int IdKilled { get; set; }
        public virtual Player Killed { get; set; }
        public DeathEnum DeathEnum { get; set; }
        public int IdGame { get; set; }
        public virtual Game Game { get; set; }
        public int IdArmor { get; set; }
        public virtual Armor Armor { get; set; }
    }
}
