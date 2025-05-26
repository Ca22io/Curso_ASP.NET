using Microsoft.AspNetCore.Mvc;

namespace Aula_3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastrar()
        {
            return View("FormUsuario");
        }

    }
}