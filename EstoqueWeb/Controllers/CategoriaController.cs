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

        private bool CategoriaExiste(int id)
        {
            return _context.Categorias.Any(x => x.IdCategoria == id);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(int? id, [FromForm] CategoriaModel categoria)
        {
            if (ModelState.IsValid)
            {
                if (id.HasValue && id.Value > 0)
                {
                    if (CategoriaExiste(id.Value))
                    {
                        _context.Update(categoria);
                        if (await _context.SaveChangesAsync() > 0)
                        {
                            TempData["mensagem"] = MensagemModel.Serializar("Categoria atualizada com sucesso!");
                        }
                        else
                        {
                            TempData["mensagem"] = MensagemModel.Serializar("Erro ao atualizar a categoria.", TipoMensagem.Erro);
                        }
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Categoria não encontrada.", TipoMensagem.Erro);
                    }
                }
                else
                {
                    _context.Add(categoria);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Categoria cadastrada com sucesso!");
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Erro ao cadastrar a categoria.", TipoMensagem.Erro);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(categoria);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Excluir(int? id)
        {
            if (!id.HasValue || id < 0)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Categoria inválida.", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }

            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Categoria não encontrada.", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }

            return View(categoria);

        }

        [HttpPost]
        public async Task<IActionResult> Excluir(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria != null)
            {
                _context.Remove(categoria);

                if (await _context.SaveChangesAsync() > 0)
                {
                    TempData["mensagem"] = MensagemModel.Serializar("Categoria excluída com sucesso!");
                }
                else
                {
                    TempData["mensagem"] = MensagemModel.Serializar("Erro ao excluir a categoria.", TipoMensagem.Erro);
                }
            }
            else
            {
                TempData["mensagem"] = MensagemModel.Serializar("Categoria inválida.", TipoMensagem.Erro);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}