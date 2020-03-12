using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Treinee.Quake.Domain.Entity;

namespace Treinee.Quake.Infra.Configuration
{
    public class GamePlayerConfiguration : IEntityTypeConfiguration<GamePlayer>
    {
        public void Configure(EntityTypeBuilder<GamePlayer> builder)
        {
            builder.ToTable("GAME_PLAYER");

            builder.HasKey(k => new { k.IdGame, k.IdPlayer });

            builder.Property(p => p.IdGame)
                   .HasColumnName("ID_GAME");

            builder.Property(p => p.IdPlayer)
                   .HasColumnName("ID_PLAYER");

            builder.Ignore(p => p.ID);
        }
    }
}
