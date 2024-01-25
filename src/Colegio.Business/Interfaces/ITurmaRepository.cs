using Colegio.Business.Models;

namespace Colegio.Business.Interfaces
{
    /// <summary>
    /// Interface de repositório para a entidade <see cref="Turma"/>
    /// </summary>
    public interface ITurmaRepository : IRepository<Turma>
    {
        /// <summary>
        /// Obter Turmas de uma Unidade de Ensino
        /// </summary>
        /// <param name="unidadeEnsinoId"></param>
        /// <returns></returns>
        Task<IEnumerable<Turma>> ObterTurmasPorUnidadeEnsino(Guid unidadeEnsinoId);

        /// <summary>
        /// Obter todas as Turmas e suas respectivas Unidades de Ensino
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Turma>> ObterTurmasUnidadeEnsino();

        /// <summary>
        /// Obter uma Turma e sua respectiva Unidade de Ensino
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Turma> ObterTurmaUnidadeEnsino(Guid id);
    }
}
