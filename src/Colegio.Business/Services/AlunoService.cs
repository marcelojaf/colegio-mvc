using Colegio.Business.Interfaces;
using Colegio.Business.Models;
using Colegio.Business.Models.Validations;

namespace Colegio.Business.Services
{
    public class AlunoService : BaseService, IAlunoService
    {
        /// <summary>
        /// Repositório de Aluno
        /// </summary>
        private readonly IAlunoRepository _alunoRepository;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="alunoRepository"></param>
        /// <param name="notificador"></param>
        public AlunoService(IAlunoRepository alunoRepository, INotificador notificador) : base(notificador)
        {
            _alunoRepository = alunoRepository;
        }

        /// <summary>
        /// Método para adicionar um Aluno
        /// </summary>
        /// <param name="aluno"></param>
        /// <returns></returns>
        public async Task Adicionar(Aluno aluno)
        {
            if (!ExecutarValidacao(new AlunoValidation(), aluno)) return;

            await _alunoRepository.Adicionar(aluno);
        }

        /// <summary>
        /// Método para atualizar um Aluno
        /// </summary>
        /// <param name="aluno"></param>
        /// <returns></returns>
        public async Task Atualizar(Aluno aluno)
        {
            if (!ExecutarValidacao(new AlunoValidation(), aluno)) return;

            await _alunoRepository.Atualizar(aluno);
        }

        /// <summary>
        /// Método para remover um Aluno
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Remover(Guid id)
        {
            await _alunoRepository.Remover(id);

        }

        /// <summary>
        /// Método para liberar os recursos da memória
        /// </summary>
        public void Dispose()
        {
            _alunoRepository?.Dispose();
        }
    }
}
