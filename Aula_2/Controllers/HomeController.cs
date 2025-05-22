using System.Diagnostics;
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
    public IActionResult Responder(Resposta form)
    {
        var respostas = TempData["Respostas"] as List<Resposta>;
        respostas.Add(form);
        TempData["Respostas"] = respostas;

        return RedirectToAction("Index");
    }

    

}
