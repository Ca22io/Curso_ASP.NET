using EstoqueWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EstoqueWeb.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly EstoqueWebContext _context;

        public CategoriaController(EstoqueWebContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Categorias.OrderBy(x => x.Nome).AsNoTracking().ToListAsync());

        }

        [HttpGet]
        public async Task<IActionResult> Cadastrar(int? id)
        {
            if (id.HasValue)
            {
                var categoria = await _context.Categorias.FindAsync(id);
                if (categoria == null)
                {
                    return NotFound();
                }
                return View(categoria);
            }
            return View(new CategoriaModel());
        }

    }  
}