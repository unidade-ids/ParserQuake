using Microsoft.EntityFrameworkCore;
using Treinee.Quake.Domain.Entity;
using Treinee.Quake.Infra.Configuration;

namespace Treinee.Quake.Infra.Context
{
    public class QuakeContext : DbContext
    {
        public DbSet<Player> Player { get; set; }
        public DbSet<Armor> Armor { get; set; }
        public DbSet<Death> Death { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<GamePlayer> GamePlayer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArmorConfiguration());
            modelBuilder.ApplyConfiguration(new DeathConfiguration());
            modelBuilder.ApplyConfiguration(new GameConfiguration());
            modelBuilder.ApplyConfiguration(new GamePlayerConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-FGIG7N0\UNIDADE_IDS;Initial Catalog=QUAKE;User Id=sa;Password=unidade;Integrated Security=True");
            }
        }
    }
}
