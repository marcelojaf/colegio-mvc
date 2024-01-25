using Colegio.Business.Models;

namespace Colegio.Business.Interfaces
{
    /// <summary>
    /// Interface de repositório para a entidade <see cref="Aluno"/>
    /// </summary>
    public interface IAlunoRepository : IRepository<Aluno>
    {
        /// <summary>
        /// Obter Alunos de uma Unidade de Ensino
        /// </summary>
        /// <param name="unidadeEnsinoId"></param>
        /// <returns></returns>
        Task<IEnumerable<Aluno>> ObterAlunosPorUnidadeEnsino(Guid unidadeEnsinoId);

        /// <summary>
        /// Obter todas os Alunos e suas respectivas Unidades de Ensino
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Aluno>> ObterAlunosUnidadeEnsino();

        /// <summary>
        /// Obter um Aluno e sua respectiva Unidade de Ensino
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Aluno> ObterAlunoUnidadeEnsino(Guid id);
    }
}
