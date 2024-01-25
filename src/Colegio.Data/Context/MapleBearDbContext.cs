using Colegio.Business.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Colegio.Data.Context
{
    /// <summary>
    /// Classe que representa o contexto do banco de dados
    /// </summary>
    public class ColegioDbContext : IdentityDbContext
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="options"></param>
        public ColegioDbContext(DbContextOptions<ColegioDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        // Propriedades DBSet

        public DbSet<UnidadeEnsino> UnidadesEnsino { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Coordenador> Coordenadores { get; set; }

        // Propriedades DBSet



        /// <summary>
        /// OnModelCreating - Configurações do banco de dados
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ColegioDbContext).Assembly);

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// SaveChanges
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            AddTimeStamps();
            return base.SaveChanges();
        }

        /// <summary>
        /// SaveChangesAsync
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddTimeStamps();

            return base.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Adiciona os TimeStamps para as propriedades CreatedDateTime e UpdatedDateTime
        /// </summary>
        private void AddTimeStamps()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedDateTime") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("CreatedDateTime").CurrentValue = DateTime.Now;
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreatedDateTime").IsModified = false;
                    entry.Property("UpdatedDateTime").CurrentValue = DateTime.Now;
                }
            }
        }
    }
}
