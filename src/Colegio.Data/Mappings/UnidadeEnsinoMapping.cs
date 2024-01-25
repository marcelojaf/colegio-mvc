using Colegio.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Colegio.Data.Mappings
{
    public class UnidadeEnsinoMapping : IEntityTypeConfiguration<UnidadeEnsino>
    {
        public void Configure(EntityTypeBuilder<UnidadeEnsino> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(p => p.Endereco)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Cidade)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.UF)
                .IsRequired()
                .HasColumnType("varchar(2)");

            builder.Property(p => p.CEP)
                .IsRequired()
                .HasColumnType("varchar(9)");

            // 1: N => UnidadeEnsino : Turmas
            builder.HasMany(u => u.Turmas)
                .WithOne(t => t.UnidadeEnsino)
                .HasForeignKey(t => t.UnidadeEnsinoId);

            builder.ToTable("UnidadesEnsino");
        }
    }
}
