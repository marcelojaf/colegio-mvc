using Colegio.App.Models;
using Colegio.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Colegio.App.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,
            INotificador notificador,
            IUser user,
            ICoordenadorRepository coordenadorRepository,
            IUnidadeEnsinoRepository unidadeEnsinoRepository) : base(notificador, user, unidadeEnsinoRepository, coordenadorRepository)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
