using Treinee.Quake.Domain.Enum;

namespace Treinee.Quake.Domain.Entity
{
    public class Death : BaseEntity
    {
        public Death(Player killer, Player killed, Game game, Armor idArmor)
        {
            this.Killer = killer;
            this.Killed = killed;
            this.Game   = game;
            this.Armor  = Armor;
        }

        protected Death() 
        {
        }

        public int IdKiller { get; private set; }
        public virtual Player Killer { get; private set; }
        public int IdKilled { get; private set; }
        public virtual Player Killed { get; private set; }
        public int IdGame { get; private set; }
        public virtual Game Game { get; private set; }
        public int IdArmor { get; private set; }
        public virtual Armor Armor { get; private set; }
    }
}
