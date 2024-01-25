using Colegio.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Colegio.App.Controllers
{
    [Authorize]
    public abstract class BaseController : Controller
    {
        private readonly INotificador _notificador;
        protected readonly IUnidadeEnsinoRepository _unidadeEnsinoRepository;
        protected readonly ICoordenadorRepository _coordenadorRepository;

        protected Guid UserId { get; set; }
        protected string UserName { get; set; }

        protected BaseController(INotificador notificador, IUser user, IUnidadeEnsinoRepository unidadeEnsinoRepository, ICoordenadorRepository coordenadorRepository)
        {
            _notificador = notificador;
            _unidadeEnsinoRepository = unidadeEnsinoRepository;
            _coordenadorRepository = coordenadorRepository;

            if (user.IsAuthenticated())
            {
                UserId = user.GetUserId();
                UserName = user.GetUserName();
            }
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }
    }
}
