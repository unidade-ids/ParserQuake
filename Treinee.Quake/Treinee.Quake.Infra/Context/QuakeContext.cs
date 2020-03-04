using Microsoft.EntityFrameworkCore;
using Treinee.Quake.Domain.Entity;

namespace Treinee.Quake.Infra.Context
{
    public class QuakeContext : DbContext
    {
        public DbSet<Player> Player { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-FGIG7N0\UNIDADE_IDS;Initial Catalog=QUAKE;User Id=sa;Password=unidade;Integrated Security=True");
            }
        }
    }
}
