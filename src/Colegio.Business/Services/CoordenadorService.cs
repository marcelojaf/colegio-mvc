using Colegio.Business.Interfaces;
using Colegio.Business.Models;
using Colegio.Business.Models.Validations;

namespace Colegio.Business.Services
{
    public class CoordenadorService : BaseService, ICoordenadorService
    {
        /// <summary>
        /// Repositório de Coordenador
        /// </summary>
        private readonly ICoordenadorRepository _coordenadorRepository;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="coordenadorRepository"></param>
        /// <param name="notificador"></param>
        public CoordenadorService(ICoordenadorRepository coordenadorRepository, INotificador notificador) : base(notificador)
        {
            _coordenadorRepository = coordenadorRepository;
        }

        /// <summary>
        /// Método para adicionar um Coordenador
        /// </summary>
        /// <param name="coordenador"></param>
        /// <returns></returns>
        public async Task Adicionar(Coordenador coordenador, Usuario usuario)
        {
            if (!ExecutarValidacao(new CoordenadorValidation(), coordenador)) return;

            await _coordenadorRepository.Adicionar(coordenador, usuario);
        }

        /// <summary>
        /// Método para atualizar um Coordenador
        /// </summary>
        /// <param name="coordenador"></param>
        /// <returns></returns>
        public async Task Atualizar(Coordenador coordenador)
        {
            if (!ExecutarValidacao(new CoordenadorValidation(), coordenador)) return;

            await _coordenadorRepository.Atualizar(coordenador);
        }

        /// <summary>
        /// Método para remover um Coordenador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Remover(Guid id)
        {
            await _coordenadorRepository.Remover(id);
        }

        /// <summary>
        /// Método para liberar os recursos da memória
        /// </summary>
        public void Dispose()
        {
            _coordenadorRepository?.Dispose();
        }
    }
}
