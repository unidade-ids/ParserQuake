using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using Treinee.Quake.Domain.Entity;
using Treinee.Quake.Infra.Configuration;

namespace Treinee.Quake.Infra.Context
{
    public class QuakeContext : DbContext
    {
        public QuakeContext(DbContextOptions<QuakeContext> options)
            :base(options)
        {
        }

        public DbSet<Player> Player { get; set; }
        public DbSet<Armor> Armor { get; set; }
        public DbSet<Death> Death { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<GamePlayer> GamePlayer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var typesToMapping = (from x in Assembly.GetExecutingAssembly().GetTypes()
                                  where x.IsClass && typeof(IConfiguration).IsAssignableFrom(x)
                                  select x).ToList();

            foreach (var mapping in typesToMapping)
            {
                dynamic mappingClass = Activator.CreateInstance(mapping);
                modelBuilder.ApplyConfiguration(mappingClass);
            }
        }
    }
}
