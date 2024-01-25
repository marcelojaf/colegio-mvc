using Colegio.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Colegio.Data.Mappings
{
    public class AlunoMapping : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nome)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(a => a.Sobrenome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(a => a.Email)
                .HasColumnType("varchar(50)");

            builder.Property(a => a.Matricula)
                .HasColumnType("varchar(50)");

            builder.ToTable("Alunos");
        }
    }
}
