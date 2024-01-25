using Colegio.Business.Models;

namespace Colegio.Business.Interfaces
{
    /// <summary>
    /// Interface de repositório para a entidade <see cref="Professor"/>
    /// </summary>
    public interface IProfessorRepository : IRepository<Professor>
    {
        /// <summary>
        /// Adiciona um Professor
        /// </summary>
        /// <param name="professor"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        Task Adicionar(Professor professor, Usuario usuario);

        /// <summary>
        /// Obter Professores de uma Unidade de Ensino
        /// </summary>
        /// <param name="unidadeEnsinoId"></param>
        /// <returns></returns>
        Task<IEnumerable<Professor>> ObterProfessoresPorUnidadeEnsino(Guid unidadeEnsinoId);

        /// <summary>
        /// Obter todas os Professores e suas respectivas Unidades de Ensino
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Professor>> ObterProfessoresUnidadeEnsino();

        /// <summary>
        /// Obter um Professor e sua respectiva Unidade de Ensino
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Professor> ObterProfessorUnidadeEnsino(Guid id);
    }
}
