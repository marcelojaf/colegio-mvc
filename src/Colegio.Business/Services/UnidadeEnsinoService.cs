using Colegio.Business.Interfaces;
using Colegio.Business.Models;
using Colegio.Business.Models.Validations;

namespace Colegio.Business.Services
{
    public class UnidadeEnsinoService : BaseService, IUnidadeEnsinoService
    {
        /// <summary>
        /// Repositório de Unidade de Ensino
        /// </summary>
        private readonly IUnidadeEnsinoRepository _unidadeEnsinoRepository;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="unidadeEnsinoRepository"></param>
        /// <param name="notificador"></param>
        public UnidadeEnsinoService(IUnidadeEnsinoRepository unidadeEnsinoRepository, INotificador notificador) : base(notificador)
        {
            _unidadeEnsinoRepository = unidadeEnsinoRepository;
        }

        /// <summary>
        /// Método para adicionar uma Unidade de Ensino
        /// </summary>
        /// <param name="unidadeEnsino"></param>
        /// <returns></returns>
        public async Task Adicionar(UnidadeEnsino unidadeEnsino)
        {
            if (!ExecutarValidacao(new UnidadeEnsinoValidation(), unidadeEnsino)) return;

            await _unidadeEnsinoRepository.Adicionar(unidadeEnsino);
        }

        /// <summary>
        /// Método para atualizar uma Unidade de Ensino
        /// </summary>
        /// <param name="unidadeEnsino"></param>
        /// <returns></returns>
        public async Task Atualizar(UnidadeEnsino unidadeEnsino)
        {
            if (!ExecutarValidacao(new UnidadeEnsinoValidation(), unidadeEnsino)) return;

            await _unidadeEnsinoRepository.Atualizar(unidadeEnsino);
        }

        /// <summary>
        /// Método para remover uma Unidade de Ensino
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Remover(Guid id)
        {
            await _unidadeEnsinoRepository.Remover(id);
        }

        /// <summary>
        /// Método para liberar os recursos da memória
        /// </summary>
        public void Dispose()
        {
            _unidadeEnsinoRepository?.Dispose();
        }
    }
}
