using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Aula_1.Controllers;

public class HomeController : Controller
{
    public ViewResult Index(int? id)
    {
        return View(id);
    }
}
