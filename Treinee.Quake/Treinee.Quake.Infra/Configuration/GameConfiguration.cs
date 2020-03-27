using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Treinee.Quake.Domain.Entity;

namespace Treinee.Quake.Infra.Configuration
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>, IConfiguration
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("GAME")
                   .HasKey(k => k.ID);

            builder.Property(p => p.ID)
                   .HasColumnName("ID");

            builder.Property(p => p.DateRegister)
                   .HasColumnName("DTH_REGISTER");

            builder.HasMany(gp => gp.GamePlayers)
                   .WithOne(gp => gp.Game)
                   .HasForeignKey(f => f.IdGame);
        }
    }
}
