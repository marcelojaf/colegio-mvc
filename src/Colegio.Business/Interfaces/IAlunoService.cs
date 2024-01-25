using Colegio.Business.Models;

namespace Colegio.Business.Interfaces
{
    public interface IAlunoService : IDisposable
    {
        Task Adicionar(Aluno aluno);
        Task Atualizar(Aluno aluno);
        Task Remover(Guid id);
    }
}
