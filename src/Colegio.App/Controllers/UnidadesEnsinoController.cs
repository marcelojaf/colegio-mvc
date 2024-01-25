using AutoMapper;
using Colegio.App.DTO;
using Colegio.Business.Interfaces;
using Colegio.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Colegio.App.Controllers
{
    public class UnidadesEnsinoController : BaseController
    {
        private readonly IUnidadeEnsinoService _unidadeEnsinoService;
        private readonly IMapper _mapper;

        public UnidadesEnsinoController(
            IUnidadeEnsinoRepository unidadeEnsinoRepository,
            ICoordenadorRepository coordenadorRepository,
            IUnidadeEnsinoService unidadeEnsinoService,
            IMapper mapper,
            INotificador notificador,
            IUser user) : base(notificador, user, unidadeEnsinoRepository, coordenadorRepository)
        {
            _unidadeEnsinoService = unidadeEnsinoService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [Route("lista-unidade-ensino")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<UnidadeEnsinoDTO>>(await _unidadeEnsinoRepository.ObterTodos()));
        }

        [AllowAnonymous]
        [Route("detalhes-unidade-ensino/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var unidadeEnsinoDTO = await ObterUnidadeEnsino(id);

            if (unidadeEnsinoDTO == null) return NotFound();

            return View(unidadeEnsinoDTO);
        }

        [Route("nova-unidade-ensino")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("nova-unidade-ensino")]
        [HttpPost]
        public async Task<IActionResult> Create(UnidadeEnsinoDTO unidadeEnsinoDTO)
        {
            if (!ModelState.IsValid) return View(unidadeEnsinoDTO);

            var unidadeEnsino = _mapper.Map<UnidadeEnsino>(unidadeEnsinoDTO);
            await _unidadeEnsinoService.Adicionar(unidadeEnsino);

            if (!OperacaoValida()) return View(unidadeEnsinoDTO);

            return RedirectToAction("Index");
        }

        [Route("editar-unidade-ensino/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var unidadeEnsinoDTO = await ObterUnidadeEnsino(id);

            if (unidadeEnsinoDTO == null) return NotFound();

            return View(unidadeEnsinoDTO);
        }

        [Route("editar-unidade-ensino/{id:guid}")]
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, UnidadeEnsinoDTO unidadeEnsinoDTO)
        {
            if (id != unidadeEnsinoDTO.Id) return NotFound();

            if (!ModelState.IsValid) return View(unidadeEnsinoDTO);

            var unidadeEnsino = _mapper.Map<UnidadeEnsino>(unidadeEnsinoDTO);
            await _unidadeEnsinoService.Atualizar(unidadeEnsino);

            if (!OperacaoValida()) return View(await ObterUnidadeEnsino(id));

            return RedirectToAction("Index");
        }

        [Route("excluir-unidade-ensino/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var unidadeEnsinoDTO = await ObterUnidadeEnsino(id);

            if (unidadeEnsinoDTO == null) return NotFound();

            return View(unidadeEnsinoDTO);
        }

        [Route("excluir-unidade-ensino/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var unidadeEnsinoDTO = await ObterUnidadeEnsino(id);

            if (unidadeEnsinoDTO == null) return NotFound();

            var unidadeEnsino = _mapper.Map<UnidadeEnsino>(unidadeEnsinoDTO);
            unidadeEnsino.Ativo = false;
            await _unidadeEnsinoService.Atualizar(unidadeEnsino);

            if (!OperacaoValida()) return View(unidadeEnsinoDTO);

            return RedirectToAction("Index");
        }

        private async Task<UnidadeEnsinoDTO> ObterUnidadeEnsino(Guid id)
        {
            return _mapper.Map<UnidadeEnsinoDTO>(await _unidadeEnsinoRepository.ObterPorId(id));
        }
    }
}
