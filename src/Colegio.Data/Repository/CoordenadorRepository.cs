using Colegio.Business.Interfaces;
using Colegio.Business.Models;
using Colegio.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Colegio.Data.Repository
{
    /// <summary>
    /// Classe de repositório para a entidade Coordenador
    /// </summary>
    public class CoordenadorRepository : Repository<Coordenador>, ICoordenadorRepository
    {
        protected readonly UserManager<IdentityUser> _userManager;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="db"></param>
        public CoordenadorRepository(ColegioDbContext db, UserManager<IdentityUser> userManager) : base(db)
        {
            _userManager = userManager;
        }

        public async Task Adicionar(Coordenador coordenador, Usuario usuario)
        {
            DbSet.Add(coordenador);

            var user = new IdentityUser()
            {
                Email = coordenador.Email,
                UserName = coordenador.Email,
                EmailConfirmed = true
            };
            await _userManager.CreateAsync(user, usuario.Senha);

            var userRole = new IdentityUserRole<string>()
            {
                RoleId = Db.Roles.AsNoTracking().Where(r => r.Name == usuario.Perfil).FirstOrDefault()?.Id ?? string.Empty,
                UserId = Db.Users.AsNoTracking().Where(u => u.Email == coordenador.Email).FirstOrDefault()?.Id ?? string.Empty
            };
            Db.UserRoles.Add(userRole);
            await Db.SaveChangesAsync();
        }

        /// <summary>
        /// Obter Coordenadores de uma Unidade de Ensino
        /// </summary>
        /// <param name="unidadeEnsinoId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Coordenador>> ObterCoordenadoresPorUnidadeEnsino(Guid unidadeEnsinoId)
        {
            return await Db.Coordenadores.AsNoTracking()
                .Where(t => t.UnidadeEnsinoId == unidadeEnsinoId && t.Ativo == true)
                .Include(t => t.UnidadeEnsino)
                .OrderBy(t => t.Nome)
                .ToListAsync();
        }

        /// <summary>
        /// Obter todas as coordenadores e suas respectivas Unidades de Ensino
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Coordenador>> ObterCoordenadoresUnidadeEnsino()
        {
            return await Db.Coordenadores.AsNoTracking()
                .Where(t => t.Ativo == true)
                .Include(t => t.UnidadeEnsino)
                .OrderBy(t => t.Nome)
                .ToListAsync();
        }

        /// <summary>
        /// Obter uma Coordenador e sua respectiva Unidade de Ensino
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Coordenador> ObterCoordenadorUnidadeEnsino(Guid id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await Db.Coordenadores.AsNoTracking()
                .Where(t => t.Ativo == true)
                .Include(t => t.UnidadeEnsino)
                .FirstOrDefaultAsync(t => t.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Coordenador> ObterCoordenadorUnidadeEnsino(string email)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await Db.Coordenadores.AsNoTracking()
                .Where(t => t.Ativo == true)
                .Include(t => t.UnidadeEnsino)
                .FirstOrDefaultAsync(t => t.Email == email);
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
