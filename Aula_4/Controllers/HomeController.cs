using Aula_4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aula_4.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            // Adicione lógica para processar o cadastro, por exemplo:
            if (ModelState.IsValid)
            { 
                Usuario.Adicionar(usuario);
                return RedirectToAction("Usuarios");
            }

            return View();
        }


        [HttpGet]
        public IActionResult Excluir()
        {
            
            return View();
        }

        [HttpGet]
        public IActionResult Excluir(int id)
        {
            Usuario.Excluir(id);
            return RedirectToAction("Usuarios");
        }


        public IActionResult Usuarios()
        {
            return View(Usuario.Listagem);
        }

    }
}