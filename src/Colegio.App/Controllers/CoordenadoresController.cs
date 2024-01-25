using AutoMapper;
using Colegio.App.DTO;
using Colegio.Business.Interfaces;
using Colegio.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Colegio.App.Controllers
{
    public class CoordenadoresController : BaseController
    {
        private readonly ICoordenadorService _coordenadorService;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public CoordenadoresController(
            ICoordenadorRepository coordenadorRepository,
            IUnidadeEnsinoRepository unidadeEnsinoRepository,
            ICoordenadorService coordenadorService,
            IMapper mapper,
            UserManager<IdentityUser> userManager,
            INotificador notificador,
            IUser user) : base(notificador, user, unidadeEnsinoRepository, coordenadorRepository)
        {
            _coordenadorService = coordenadorService;
            _mapper = mapper;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [Route("lista-coordenador")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<CoordenadorDTO>>(await _coordenadorRepository.ObterTodos()));
        }

        [AllowAnonymous]
        [Route("detalhes-coordenador/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var coordenadorDTO = await ObterCoordenador(id);

            if (coordenadorDTO == null) return NotFound();

            return View(coordenadorDTO);
        }

        [Route("novo-coordenador")]
        public async Task<IActionResult> Create()
        {
            var coordenadorDTO = await PopularUnidadesEnsino(new CoordenadorDTO());

            return View(coordenadorDTO);
        }

        [Route("novo-coordenador")]
        [HttpPost]
        public async Task<IActionResult> Create(CoordenadorDTO coordenadorDTO)
        {
            coordenadorDTO = await PopularUnidadesEnsino(new CoordenadorDTO());

            if (!ModelState.IsValid) return View(coordenadorDTO);

            var coordenador = _mapper.Map<Coordenador>(coordenadorDTO);

            var usuario = new Usuario()
            {
                Senha = coordenadorDTO.Senha,
                Perfil = "Coordenador"
            };
            await _coordenadorService.Adicionar(coordenador, usuario);

            if (!OperacaoValida()) return View(coordenadorDTO);

            return RedirectToAction("Index");
        }

        [Route("editar-coordenador/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var coordenadorDTO = await ObterCoordenador(id);

            if (coordenadorDTO == null) return NotFound();

            return View(coordenadorDTO);
        }

        [Route("editar-coordenador/{id:guid}")]
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, CoordenadorDTOAtualizar coordenadorDTO)
        {
            if (id != coordenadorDTO.Id) return NotFound();

            if (!ModelState.IsValid) return View(coordenadorDTO);

            var coordenador = _mapper.Map<Coordenador>(coordenadorDTO);
            await _coordenadorService.Atualizar(coordenador);

            if (!OperacaoValida()) return View(await ObterCoordenador(id));

            return RedirectToAction(nameof(Index));
        }

        [Route("excluir-coordenador/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var coordenadorDTO = await ObterCoordenador(id);

            if (coordenadorDTO == null) return NotFound();

            return View(coordenadorDTO);
        }

        [Route("excluir-coordenador/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var coordenadorDTO = await ObterCoordenador(id);

            if (coordenadorDTO == null) return NotFound();

            var coordenador = _mapper.Map<Coordenador>(coordenadorDTO);
            coordenador.Ativo = false;
            await _coordenadorService.Atualizar(coordenador);

            if (!OperacaoValida()) return View(coordenadorDTO);

            return RedirectToAction(nameof(Index));
        }


        private async Task<CoordenadorDTO> ObterCoordenador(Guid id)
        {
            var coordenadorDTO = _mapper.Map<CoordenadorDTO>(await _coordenadorRepository.ObterCoordenadorUnidadeEnsino(id));
            coordenadorDTO.UnidadesEnsino = _mapper.Map<IEnumerable<UnidadeEnsinoDTO>>(await _unidadeEnsinoRepository.ObterTodos());
            return coordenadorDTO;
        }

        private async Task<CoordenadorDTO> PopularUnidadesEnsino(CoordenadorDTO coordenadorDTO)
        {
            coordenadorDTO.UnidadesEnsino = _mapper.Map<IEnumerable<UnidadeEnsinoDTO>>(await _unidadeEnsinoRepository.ObterTodos());

            return coordenadorDTO;
        }
    }
}
