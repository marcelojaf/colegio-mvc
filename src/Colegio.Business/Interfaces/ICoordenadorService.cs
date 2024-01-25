using Colegio.Business.Models;

namespace Colegio.Business.Interfaces
{
    public interface ICoordenadorService : IDisposable
    {
        Task Adicionar(Coordenador professor, Usuario usuario);
        Task Atualizar(Coordenador professor);
        Task Remover(Guid id);
    }
}
