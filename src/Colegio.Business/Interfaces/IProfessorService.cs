using Colegio.Business.Models;

namespace Colegio.Business.Interfaces
{
    public interface IProfessorService : IDisposable
    {
        Task Adicionar(Professor professor, Usuario usuario);
        Task Atualizar(Professor professor);
        Task Remover(Guid id);
    }
}
