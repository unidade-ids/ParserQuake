using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Treinee.Quake.Domain.Entity;

namespace Treinee.Quake.Infra.Configuration
{
    public class DeathConfiguration : IEntityTypeConfiguration<Death>
    {
        public void Configure(EntityTypeBuilder<Death> builder)
        {
            builder.ToTable("DEATH")
                   .HasKey(k => k.ID);

            builder.Property(p => p.ID)
                .HasColumnName("ID");

            builder.Property(p => p.IdKiller)
                .HasColumnName("ID_KILLER");

            builder.Property(p => p.IdKilled)
                   .HasColumnName("ID_KILLED");

            builder.Property(p => p.IdArmor)
                   .HasColumnName("ID_ARMOR");

            builder.Property(p => p.IdGame)
                .HasColumnName("ID_GAME");

            builder.HasOne(k => k.Killer)
                .WithMany(k => k.KillerDeaths)
                .HasForeignKey(f => f.IdKiller);

            builder.HasOne(k => k.Killed)
                   .WithMany(k => k.KilledDeaths)
                   .HasForeignKey(f => f.IdKilled);

            builder.HasOne(k => k.Armor)
                   .WithMany(k => k.Deaths)
                   .HasForeignKey(f => f.IdArmor);

            builder.HasOne(k => k.Game)
                   .WithMany(k => k.Deaths)
                   .HasForeignKey(f => f.IdGame);

        }
    }
}
