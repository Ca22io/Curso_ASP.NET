using EstoqueWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EstoqueWeb.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly EstoqueWebContext _context;

        public ProdutoController(EstoqueWebContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Produtos.OrderBy(x => x.Nome).Include(x => x.Categoria).AsNoTracking().ToListAsync());

        }

        [HttpGet]
        public async Task<IActionResult> Cadastrar(int? id)
        {
            var categorias = await _context.Categorias.OrderBy(x => x.Nome).AsNoTracking().ToListAsync();
            var categoriaSelectList = new SelectList(categorias, nameof(CategoriaModel.IdCategoria), nameof(CategoriaModel.Nome));

            ViewBag.Categorias = categoriaSelectList;

            if (id.HasValue)
            {
                var produto = await _context.Produtos.FindAsync(id);
                if (produto == null)
                {
                    return NotFound();
                }
                return View(produto);
            }
            return View(new ProdutoModel());
        }

        private bool ProdutoExiste(int id)
        {
            return _context.Produtos.Any(x => x.IdProduto == id);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(int? id, [FromForm] ProdutoModel produto)
        {
            if (ModelState.IsValid)
            {
                if (id.HasValue && id.Value > 0)
                {
                    if (ProdutoExiste(id.Value))
                    {
                        _context.Update(produto);
                        if (await _context.SaveChangesAsync() > 0)
                        {
                            TempData["mensagem"] = MensagemModel.Serializar("Produto atualizado com sucesso!");
                        }
                        else
                        {
                            TempData["mensagem"] = MensagemModel.Serializar("Erro ao atualizar o produto.", TipoMensagem.Erro);
                        }
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Produto não encontrado.", TipoMensagem.Erro);
                    }
                }
                else
                {
                    _context.Add(produto);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Produto cadastrado com sucesso!");
                    }
                    else
                    {
                        TempData["mensagem"] = MensagemModel.Serializar("Erro ao cadastrar o produto.", TipoMensagem.Erro);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(produto);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Excluir(int? id)
        {
            if (!id.HasValue || id < 0)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Produto inválido.", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }

            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Produto não encontrado.", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }

            return View(produto);

        }

        [HttpPost]
        public async Task<IActionResult> Excluir(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto != null)
            {
                _context.Remove(produto);

                if (await _context.SaveChangesAsync() > 0)
                {
                    TempData["mensagem"] = MensagemModel.Serializar("Produto excluído com sucesso!");
                }
                else
                {
                    TempData["mensagem"] = MensagemModel.Serializar("Erro ao excluir o produto.", TipoMensagem.Erro);
                }
            }
            else
            {
                TempData["mensagem"] = MensagemModel.Serializar("Produto inválido.", TipoMensagem.Erro);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}