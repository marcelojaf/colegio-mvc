using Colegio.Business.Models;

namespace Colegio.Business.Interfaces
{
    /// <summary>
    /// Interface de repositório para a entidade <see cref="Coordenador"/>
    /// </summary>
    public interface ICoordenadorRepository : IRepository<Coordenador>
    {
        /// <summary>
        /// Adiciona um Coordenador
        /// </summary>
        /// <param name="coordenador"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        Task Adicionar(Coordenador coordenador, Usuario usuario);

        /// <summary>
        /// Obter Coordenadores de uma Unidade de Ensino
        /// </summary>
        /// <param name="unidadeEnsinoId"></param>
        /// <returns></returns>
        Task<IEnumerable<Coordenador>> ObterCoordenadoresPorUnidadeEnsino(Guid unidadeEnsinoId);

        /// <summary>
        /// Obter todas os Coordenadores e suas respectivas Unidades de Ensino
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Coordenador>> ObterCoordenadoresUnidadeEnsino();

        /// <summary>
        /// Obter um Coordenador e sua respectiva Unidade de Ensino
        /// </summary>
        /// <param name="id">Id do Coordenador</param>
        /// <returns></returns>
        Task<Coordenador> ObterCoordenadorUnidadeEnsino(Guid id);

        /// <summary>
        /// Obter um Coordenador e sua respectiva Unidade de Ensino
        /// </summary>
        /// <param name="email">Email do Coordenador</param>
        /// <returns></returns>
        Task<Coordenador> ObterCoordenadorUnidadeEnsino(string email);
    }
}
