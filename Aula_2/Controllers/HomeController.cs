using Microsoft.AspNetCore.Mvc;
using Aula_2.Models;

namespace Aula_2.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Responder()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Responder(Resposta reposta)
    {
        if (ModelState.IsValid)
        {
            Repositorio.AdicionarResposta(reposta);
            return View("Obrigado");
        }
        else
        {
            return View(reposta);
        }
        
        
    }

    [HttpGet]
    public IActionResult Resultado()
    {
        return View(Repositorio.Respostas);
    }
}
