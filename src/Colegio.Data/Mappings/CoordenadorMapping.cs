using Colegio.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Colegio.Data.Mappings
{
    public class CoordenadorMapping : IEntityTypeConfiguration<Coordenador>
    {
        public void Configure(EntityTypeBuilder<Coordenador> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Sobrenome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Email)
                .HasColumnType("varchar(50)");

            builder.ToTable("Coordenadores");
        }
    }
}
