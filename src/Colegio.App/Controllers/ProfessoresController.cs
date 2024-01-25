using AutoMapper;
using Colegio.App.DTO;
using Colegio.Business.Interfaces;
using Colegio.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Colegio.App.Controllers
{
    public class ProfessoresController : BaseController
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IProfessorService _professorService;
        private readonly IMapper _mapper;

        public ProfessoresController(
            IProfessorRepository professorRepository,
            IProfessorService professorService,
            IUnidadeEnsinoRepository unidadeEnsinoRepository,
            ICoordenadorRepository coordenadorRepository,
            IMapper mapper,
            INotificador notificador,
            IUser user) : base(notificador, user, unidadeEnsinoRepository, coordenadorRepository)
        {
            _professorRepository = professorRepository;
            _professorService = professorService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [Route("lista-professor")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProfessorDTO>>(await _professorRepository.ObterTodos()));
        }

        [AllowAnonymous]
        [Route("detalhes-professor/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var professorDTO = await ObterProfessor(id);

            if (professorDTO == null) return NotFound();

            return View(professorDTO);
        }

        [Route("novo-professor")]
        public async Task<IActionResult> Create()
        {
            var professorDTO = await PopularUnidadesEnsino(new ProfessorDTO());

            return View(professorDTO);
        }

        [Route("novo-professor")]
        [HttpPost]
        public async Task<IActionResult> Create(ProfessorDTO professorDTO)
        {
            professorDTO = await PopularUnidadesEnsino(new ProfessorDTO());
            var coordenador = await _coordenadorRepository.ObterCoordenadorUnidadeEnsino(UserName);
            if (coordenador == null) return View(professorDTO);

            professorDTO.UnidadeEnsinoId = coordenador.UnidadeEnsinoId;

            if (!ModelState.IsValid) return View(professorDTO);

            var professor = _mapper.Map<Professor>(professorDTO);
            var usuario = new Usuario()
            {
                Senha = professorDTO.Senha,
                Perfil = "Professor"
            };
            await _professorService.Adicionar(professor, usuario);

            if (!OperacaoValida()) return View(professorDTO);

            return RedirectToAction("Index");
        }

        [Route("editar-professor/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var professorDTO = await ObterProfessor(id);

            if (professorDTO == null) return NotFound();

            return View(professorDTO);
        }

        [Route("editar-professor/{id:guid}")]
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, ProfessorDTOAtualizar professorDTO)
        {
            if (id != professorDTO.Id) return NotFound();

            if (!ModelState.IsValid) return View(professorDTO);

            var professor = _mapper.Map<Professor>(professorDTO);
            await _professorService.Atualizar(professor);

            if (!OperacaoValida()) return View(await ObterProfessor(id));

            return RedirectToAction(nameof(Index));
        }

        [Route("excluir-professor/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var professorDTO = await ObterProfessor(id);

            if (professorDTO == null) return NotFound();

            return View(professorDTO);
        }

        [Route("excluir-professor/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var professorDTO = await ObterProfessor(id);

            if (professorDTO == null) return NotFound();

            var professor = _mapper.Map<Professor>(professorDTO);
            professor.Ativo = false;
            await _professorService.Atualizar(professor);

            if (!OperacaoValida()) return View(professorDTO);

            return RedirectToAction(nameof(Index));
        }


        private async Task<ProfessorDTO> ObterProfessor(Guid id)
        {
            var professorDTO = _mapper.Map<ProfessorDTO>(await _professorRepository.ObterProfessorUnidadeEnsino(id));
            professorDTO.UnidadesEnsino = _mapper.Map<IEnumerable<UnidadeEnsinoDTO>>(await _unidadeEnsinoRepository.ObterTodos());
            return professorDTO;
        }

        private async Task<ProfessorDTO> PopularUnidadesEnsino(ProfessorDTO professorDTO)
        {
            professorDTO.UnidadesEnsino = _mapper.Map<IEnumerable<UnidadeEnsinoDTO>>(await _unidadeEnsinoRepository.ObterTodos());

            return professorDTO;
        }
    }
}
