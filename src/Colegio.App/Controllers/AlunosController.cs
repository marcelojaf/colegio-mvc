using AutoMapper;
using Colegio.App.DTO;
using Colegio.Business.Interfaces;
using Colegio.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Colegio.App.Controllers
{
    public class AlunosController : BaseController
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IAlunoService _alunoService;
        private readonly IMapper _mapper;

        public AlunosController(
            IAlunoRepository alunoRepository,
            IUnidadeEnsinoRepository unidadeEnsinoRepository,
            ICoordenadorRepository coordenadorRepository,
            IAlunoService alunoService,
            IMapper mapper,
            INotificador notificador,
            IUser user) : base(notificador, user, unidadeEnsinoRepository, coordenadorRepository)
        {
            _alunoRepository = alunoRepository;
            _alunoService = alunoService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [Route("lista-aluno")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<AlunoDTO>>(await _alunoRepository.ObterTodos()));
        }

        [AllowAnonymous]
        [Route("detalhes-aluno/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var alunoDTO = await ObterAluno(id);

            if (alunoDTO == null) return NotFound();

            return View(alunoDTO);
        }

        [Route("novo-aluno")]
        public async Task<IActionResult> Create()
        {
            var alunoDTO = await PopularUnidadesEnsino(new AlunoDTO());

            return View(alunoDTO);
        }

        [Route("novo-aluno")]
        [HttpPost]
        public async Task<IActionResult> Create(AlunoDTO alunoDTO)
        {
            alunoDTO = await PopularUnidadesEnsino(new AlunoDTO());

            if (!ModelState.IsValid) return View(alunoDTO);

            var aluno = _mapper.Map<Aluno>(alunoDTO);

            await _alunoService.Adicionar(aluno);

            if (!OperacaoValida()) return View(alunoDTO);

            return RedirectToAction("Index");
        }

        [Route("editar-aluno/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var alunoDTO = await ObterAluno(id);

            if (alunoDTO == null) return NotFound();

            return View(alunoDTO);
        }

        [Route("editar-aluno/{id:guid}")]
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, AlunoDTO alunoDTO)
        {
            if (id != alunoDTO.Id) return NotFound();

            if (!ModelState.IsValid) return View(alunoDTO);

            var aluno = _mapper.Map<Aluno>(alunoDTO);
            await _alunoService.Atualizar(aluno);

            if (!OperacaoValida()) return View(await ObterAluno(id));

            return RedirectToAction(nameof(Index));
        }

        [Route("excluir-aluno/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var alunoDTO = await ObterAluno(id);

            if (alunoDTO == null) return NotFound();

            return View(alunoDTO);
        }

        [Route("excluir-aluno/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var alunoDTO = await ObterAluno(id);

            if (alunoDTO == null) return NotFound();

            var aluno = _mapper.Map<Aluno>(alunoDTO);
            aluno.Ativo = false;
            await _alunoService.Atualizar(aluno);
            if (!OperacaoValida()) return View(alunoDTO);

            return RedirectToAction(nameof(Index));
        }


        private async Task<AlunoDTO> ObterAluno(Guid id)
        {
            return _mapper.Map<AlunoDTO>(await _alunoRepository.ObterAlunoUnidadeEnsino(id));
        }

        private async Task<AlunoDTO> PopularUnidadesEnsino(AlunoDTO alunoDTO)
        {
            alunoDTO.UnidadesEnsino = _mapper.Map<IEnumerable<UnidadeEnsinoDTO>>(await _unidadeEnsinoRepository.ObterTodos());

            return alunoDTO;
        }
    }
}
