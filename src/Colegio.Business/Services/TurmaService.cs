using Colegio.Business.Interfaces;
using Colegio.Business.Models;
using Colegio.Business.Models.Validations;

namespace Colegio.Business.Services
{
    public class TurmaService : BaseService, ITurmaService
    {
        /// <summary>
        /// Repositório de Unidade de Ensino
        /// </summary>
        private readonly ITurmaRepository _turmaRepository;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="turmaRepository"></param>
        /// <param name="notificador"></param>
        public TurmaService(ITurmaRepository turmaRepository, INotificador notificador) : base(notificador)
        {
            _turmaRepository = turmaRepository;
        }

        /// <summary>
        /// Método para adicionar uma Unidade de Ensino
        /// </summary>
        /// <param name="turma"></param>
        /// <returns></returns>
        public async Task Adicionar(Turma turma)
        {
            if (!ExecutarValidacao(new TurmaValidation(), turma)) return;

            await _turmaRepository.Adicionar(turma);
        }

        /// <summary>
        /// Método para atualizar uma Unidade de Ensino
        /// </summary>
        /// <param name="turma"></param>
        /// <returns></returns>
        public async Task Atualizar(Turma turma)
        {
            if (!ExecutarValidacao(new TurmaValidation(), turma)) return;

            await _turmaRepository.Atualizar(turma);
        }

        /// <summary>
        /// Método para remover uma Unidade de Ensino
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Remover(Guid id)
        {
            await _turmaRepository.Remover(id);
        }

        /// <summary>
        /// Método para liberar os recursos da memória
        /// </summary>
        public void Dispose()
        {
            _turmaRepository?.Dispose();
        }
    }
}
