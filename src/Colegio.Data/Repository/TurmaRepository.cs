using Colegio.Business.Interfaces;
using Colegio.Business.Models;
using Colegio.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Colegio.Data.Repository
{
    /// <summary>
    /// Classe de repositório para a entidade Turma
    /// </summary>
    public class TurmaRepository : Repository<Turma>, ITurmaRepository
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="db"></param>
        public TurmaRepository(ColegioDbContext db) : base(db)
        {
        }

        /// <summary>
        /// Obter Turmas de uma Unidade de Ensino
        /// </summary>
        /// <param name="unidadeEnsinoId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Turma>> ObterTurmasPorUnidadeEnsino(Guid unidadeEnsinoId)
        {
            return await Db.Turmas.AsNoTracking()
                .Where(t => t.UnidadeEnsinoId == unidadeEnsinoId && t.Ativo == true)
                .Include(t => t.UnidadeEnsino)
                .OrderBy(t => t.Nome)
                .ToListAsync();
        }

        /// <summary>
        /// Obter todas as turmas e suas respectivas Unidades de Ensino
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Turma>> ObterTurmasUnidadeEnsino()
        {
            return await Db.Turmas.AsNoTracking()
                .Where(t => t.Ativo == true)
                .Include(t => t.UnidadeEnsino)
                .OrderBy(t => t.Nome)
                .ToListAsync();
        }

        /// <summary>
        /// Obter uma Turma e sua respectiva Unidade de Ensino
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Turma> ObterTurmaUnidadeEnsino(Guid id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await Db.Turmas.AsNoTracking()
                .Where(t => t.Ativo == true)
                .Include(t => t.UnidadeEnsino)
                .FirstOrDefaultAsync(t => t.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
