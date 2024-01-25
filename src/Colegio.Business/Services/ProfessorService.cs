using Colegio.Business.Interfaces;
using Colegio.Business.Models;
using Colegio.Business.Models.Validations;

namespace Colegio.Business.Services
{
    public class ProfessorService : BaseService, IProfessorService
    {
        /// <summary>
        /// Repositório de Professor
        /// </summary>
        private readonly IProfessorRepository _professorRepository;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="professorRepository"></param>
        /// <param name="notificador"></param>
        public ProfessorService(IProfessorRepository professorRepository, INotificador notificador) : base(notificador)
        {
            _professorRepository = professorRepository;
        }

        /// <summary>
        /// Método para adicionar um Professor
        /// </summary>
        /// <param name="professor"></param>
        /// <returns></returns>
        public async Task Adicionar(Professor professor, Usuario usuario)
        {
            if (!ExecutarValidacao(new ProfessorValidation(), professor)) return;

            await _professorRepository.Adicionar(professor, usuario);
        }

        /// <summary>
        /// Método para atualizar um Professor
        /// </summary>
        /// <param name="professor"></param>
        /// <returns></returns>
        public async Task Atualizar(Professor professor)
        {
            if (!ExecutarValidacao(new ProfessorValidation(), professor)) return;

            await _professorRepository.Atualizar(professor);
        }

        /// <summary>
        /// Método para remover um Professor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Remover(Guid id)
        {
            await _professorRepository.Remover(id);
        }

        /// <summary>
        /// Método para liberar os recursos da memória
        /// </summary>
        public void Dispose()
        {
            _professorRepository?.Dispose();
        }
    }
}
