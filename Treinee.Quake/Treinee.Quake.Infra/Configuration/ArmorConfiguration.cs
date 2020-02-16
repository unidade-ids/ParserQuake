using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Treinee.Quake.Domain.Entity;

namespace Treinee.Quake.Infra.Configuration
{
    public class ArmorConfiguration : IEntityTypeConfiguration<Armor>
    {
        public void Configure(EntityTypeBuilder<Armor> builder)
        {
            builder.ToTable("ARMOR")
                .HasKey(k => k.ID);

            builder.Property(p => p.ID)
                .HasColumnName("ID");

            builder.Property(p => p.Description)
                .HasColumnName("DESCRIPTION");
        }
    }
}
