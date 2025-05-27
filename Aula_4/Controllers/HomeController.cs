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


        public IActionResult Excluir(int itemId)
        {
            // Verifica se o item existe
            var usuario = Usuario.Listagem.First(u => u.Id == itemId);
            if (usuario == null)
            {
                return NotFound();
            }

            // Passa o usuário para a view de exclusão
            return View(usuario);
        }


        public IActionResult ExcluirConfirmado(int itemId)
        {
            Usuario.Excluir(itemId);
            return RedirectToAction("Usuarios");
        }

        public IActionResult Alterar(int itemId)
        {
            // Verifica se o item existe
            var usuario = Usuario.Listagem.First(u => u.Id == itemId);
            if (usuario == null)
            {
                return NotFound();
            }

            // Passa o usuário para a view de edição
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Alterar(Usuario usuario)
        {
            // Verifica se o modelo é válido
            if (ModelState.IsValid)
            {
                Usuario.Alterar(usuario);
                return RedirectToAction("Usuarios");
            }

            // Se o modelo não for válido, retorna à view de edição
            return View(usuario);
        }


        public IActionResult Usuarios()
        {
            return View(Usuario.Listagem);
        }

    }
}