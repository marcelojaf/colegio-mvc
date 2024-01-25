using Colegio.Business.Models;

namespace Colegio.Business.Interfaces
{
    /// <summary>
    /// Interface de serviço de Unidade de Ensino
    /// </summary>
    public interface IUnidadeEnsinoService : IDisposable
    {
        Task Adicionar(UnidadeEnsino unidadeEnsino);

        Task Atualizar(UnidadeEnsino unidadeEnsino);

        Task Remover(Guid id);
    }
}
