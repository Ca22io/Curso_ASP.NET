using System.Text;
using App.Extensions;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailService _emailService;

        public HomeController(IEmailService emailService)
        {
            _emailService = emailService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> EnviarEmailTeste()
        {
            var html = new StringBuilder();

            html.Append("<h1>Teste de Serviço de Envio de E-mail</h1>");

            html.Append("<p>Este é um e-mail de teste enviado com o serviço de envio de e-mails do Gmail.</p>");
            
            await _emailService.SendEmailAsync("bindaco77@gmail.com", "Teste de Serviço de E-mail", string.Empty, html.ToString());

            this.MostrarMensagem("E-mail enviado com sucesso!");

            return RedirectToAction(nameof(Index));
        }
    }
}