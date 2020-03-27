using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Treinee.Quake.Domain.Entity;

namespace Treinee.Quake.Infra.Configuration
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>, IConfiguration
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("PLAYER")
                .HasKey(k => k.ID);

            builder.Property(p => p.Name)
                   .HasColumnName("NAME");

            builder.Property(p => p.DataRegister)
                   .HasColumnName("DTH_REGISTER");

            builder.HasMany(gp => gp.GamePlayers)
                   .WithOne(gp => gp.Player)
                   .HasForeignKey(f => f.IdPlayer);
        }
    }
}
