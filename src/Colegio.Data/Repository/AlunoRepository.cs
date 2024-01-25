using Colegio.Business.Interfaces;
using Colegio.Business.Models;
using Colegio.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Colegio.Data.Repository
{
    /// <summary>
    /// Classe de repositório para a entidade Aluno
    /// </summary>
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="db"></param>
        public AlunoRepository(ColegioDbContext db) : base(db)
        {
        }

        /// <summary>
        /// Obter Alunos de uma Unidade de Ensino
        /// </summary>
        /// <param name="unidadeEnsinoId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Aluno>> ObterAlunosPorUnidadeEnsino(Guid unidadeEnsinoId)
        {
            return await Db.Alunos.AsNoTracking()
                .Where(t => t.UnidadeEnsinoId == unidadeEnsinoId && t.Ativo == true)
                .Include(t => t.UnidadeEnsino)
                .OrderBy(t => t.Nome)
                .ToListAsync();
        }

        /// <summary>
        /// Obter todas os alunos e suas respectivas Unidades de Ensino
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Aluno>> ObterAlunosUnidadeEnsino()
        {
            return await Db.Alunos.AsNoTracking()
                .Where(t => t.Ativo == true)
                .Include(t => t.UnidadeEnsino)
                .OrderBy(t => t.Nome)
                .ToListAsync();
        }

        /// <summary>
        /// Obter um Aluno e sua respectiva Unidade de Ensino
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Aluno> ObterAlunoUnidadeEnsino(Guid id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await Db.Alunos.AsNoTracking()
                .Where(t => t.Ativo == true)
                .Include(t => t.UnidadeEnsino)
                .FirstOrDefaultAsync(t => t.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
