using Colegio.Business.Models;

namespace Colegio.Business.Interfaces
{
    /// <summary>
    /// Interface de serviço de Turma
    /// </summary>
    public interface ITurmaService : IDisposable
    {
        Task Adicionar(Turma turma);

        Task Atualizar(Turma turma);

        Task Remover(Guid id);
    }
}
