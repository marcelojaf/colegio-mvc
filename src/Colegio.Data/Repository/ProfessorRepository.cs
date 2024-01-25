using Colegio.Business.Interfaces;
using Colegio.Business.Models;
using Colegio.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Colegio.Data.Repository
{
    /// <summary>
    /// Classe de repositório para a entidade Professor
    /// </summary>
    public class ProfessorRepository : Repository<Professor>, IProfessorRepository
    {
        protected readonly UserManager<IdentityUser> _userManager;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="db"></param>
        public ProfessorRepository(ColegioDbContext db, UserManager<IdentityUser> userManager) : base(db)
        {
            _userManager = userManager;
        }

        public async Task Adicionar(Professor professor, Usuario usuario)
        {
            DbSet.Add(professor);

            var user = new IdentityUser()
            {
                Email = professor.Email,
                UserName = professor.Email,
                EmailConfirmed = true
            };
            await _userManager.CreateAsync(user, usuario.Senha);

            var userRole = new IdentityUserRole<string>()
            {
                RoleId = Db.Roles.AsNoTracking().Where(r => r.Name == usuario.Perfil).FirstOrDefault()?.Id ?? string.Empty,
                UserId = Db.Users.AsNoTracking().Where(u => u.Email == professor.Email).FirstOrDefault()?.Id ?? string.Empty
            };
            Db.UserRoles.Add(userRole);
            await Db.SaveChangesAsync();
        }

        /// <summary>
        /// Obter Professores de uma Unidade de Ensino
        /// </summary>
        /// <param name="unidadeEnsinoId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Professor>> ObterProfessoresPorUnidadeEnsino(Guid unidadeEnsinoId)
        {
            return await Db.Professores.AsNoTracking()
                .Where(t => t.UnidadeEnsinoId == unidadeEnsinoId && t.Ativo == true)
                .Include(t => t.UnidadeEnsino)
                .OrderBy(t => t.Nome)
                .ToListAsync();
        }

        /// <summary>
        /// Obter todas as professores e suas respectivas Unidades de Ensino
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Professor>> ObterProfessoresUnidadeEnsino()
        {
            return await Db.Professores.AsNoTracking()
                .Where(t => t.Ativo == true)
                .Include(t => t.UnidadeEnsino)
                .OrderBy(t => t.Nome)
                .ToListAsync();
        }

        /// <summary>
        /// Obter uma Professor e sua respectiva Unidade de Ensino
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Professor> ObterProfessorUnidadeEnsino(Guid id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await Db.Professores.AsNoTracking()
                .Where(t => t.Ativo == true)
                .Include(t => t.UnidadeEnsino)
                .FirstOrDefaultAsync(t => t.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
