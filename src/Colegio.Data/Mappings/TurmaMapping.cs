using Colegio.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Colegio.Data.Mappings
{
    public class TurmaMapping : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(500)");

            builder.Property(p => p.Periodo)
                .IsRequired()
                .HasColumnType("int");

            builder.ToTable("Turmas");
        }
    }
}
