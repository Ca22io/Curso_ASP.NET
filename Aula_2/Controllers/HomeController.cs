using Microsoft.AspNetCore.Mvc;
using Aula_2.Models;

namespace Aula_2.Controllers;

// Controlador responsável pelas ações da Home
public class HomeController : Controller
{
    // Ação padrão que retorna a view inicial (Index)
    public IActionResult Index()
    {
        return View();
    }

    // Ação GET para exibir o formulário de resposta
    [HttpGet]
    public IActionResult Responder()
    {
        return View();
    }

    // Ação POST para processar o envio do formulário de resposta
    [HttpPost]
    public IActionResult Responder(Resposta reposta)
    {
        // Verifica se os dados enviados são válidos conforme as validações do modelo
        if (ModelState.IsValid)
        {
            // Adiciona a resposta ao repositório se for válida
            Repositorio.AdicionarResposta(reposta);
            // Retorna a view de agradecimento
            return View("Obrigado");
        }
        else
        {
            // Caso haja erros de validação, retorna a view com os dados preenchidos para correção
            return View(reposta);
        }
    }

    // Ação GET para exibir o resultado com todas as respostas armazenadas
    [HttpGet]
    public IActionResult Resultado()
    {
        // Passa a lista de respostas do repositório para a view
        return View(Repositorio.Respostas);
    }
}
