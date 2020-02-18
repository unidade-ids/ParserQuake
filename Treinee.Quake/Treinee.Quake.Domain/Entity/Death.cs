using Treinee.Quake.Domain.Enum;

namespace Treinee.Quake.Domain.Entity
{
    public class Death : BaseEntity
    {
        public Death(Player killer, Player killed, DeathEnum deathEnum, Game game, Armor armor)
        {
            this.Killer    = killer;
            this.Killed    = killed;
            this.DeathEnum = deathEnum;
            this.Game      = game;
            this.Armor     = armor;
        }

        protected Death() 
        {
        }

        public int IdKiller { get; private set; }
        public virtual Player Killer { get; private set; }
        public int IdKilled { get; private set; }
        public virtual Player Killed { get; private set; }
        public DeathEnum DeathEnum { get; private set; }
        public int IdGame { get; private set; }
        public virtual Game Game { get; private set; }
        public int IdArmor { get; private set; }
        public virtual Armor Armor { get; private set; }
    }
}
