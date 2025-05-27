// Importa o namespace Aula_4.Models, que contém a definição da classe Usuario utilizada neste controller
using Aula_4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aula_4.Controllers
{

    // Define a classe HomeController que herda de Controller, responsável por gerenciar as ações relacionadas à entidade "Usuario"
    public class HomeController : Controller
    {
        /// <summary>
        /// Ação padrão que retorna a view inicial.
        /// </summary>
        /// <returns>Retorna a view padrão Index.</returns>
        public IActionResult Index()
        {
            // Retorna a view associada à ação Index
            return View();
        }

        /// <summary>
        /// Exibe o formulário de cadastro de usuário (requisição GET).
        /// </summary>
        /// <returns>Retorna a view de cadastro.</returns>
        [HttpGet]
        public IActionResult Cadastrar()
        {
            // Retorna a view para cadastro de usuário
            return View();
        }

        /// <summary>
        /// Processa o envio do formulário de cadastro de usuário (requisição POST).
        /// </summary>
        /// <param name="usuario">Objeto Usuario preenchido pelo formulário.</param>
        /// <returns>Redireciona para a lista de usuários se válido, senão retorna a view de cadastro.</returns>
        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            // Verifica se o modelo recebido é válido
            if (ModelState.IsValid)
            { 
                // Salva o usuário utilizando o método estático Salvar
                Usuario.Salvar(usuario);
                // Redireciona para a ação Usuarios após o cadastro
                return RedirectToAction("Usuarios");
            }

            // Se o modelo não for válido, retorna a view de cadastro novamente
            return View();
        }

        /// <summary>
        /// Exibe a confirmação de exclusão de um usuário.
        /// </summary>
        /// <param name="itemId">ID do usuário a ser excluído.</param>
        /// <returns>Retorna a view de confirmação de exclusão ou NotFound se não existir.</returns>
        public IActionResult Excluir(int itemId)
        {
            // Busca o usuário na listagem pelo ID
            var usuario = Usuario.Listagem.First(u => u.Id == itemId);
            // Se o usuário não existir, retorna NotFound
            if (usuario == null)
            {
                return NotFound();
            }

            // Retorna a view de exclusão passando o usuário encontrado
            return View(usuario);
        }

        /// <summary>
        /// Confirma e executa a exclusão do usuário.
        /// </summary>
        /// <param name="itemId">ID do usuário a ser excluído.</param>
        /// <returns>Redireciona para a lista de usuários após exclusão.</returns>
        public IActionResult ExcluirConfirmado(int itemId)
        {
            // Exclui o usuário pelo ID usando o método estático Excluir
            Usuario.Excluir(itemId);
            // Redireciona para a ação Usuarios após a exclusão
            return RedirectToAction("Usuarios");
        }

        /// <summary>
        /// Exibe o formulário para alteração dos dados de um usuário.
        /// </summary>
        /// <param name="itemId">ID do usuário a ser alterado.</param>
        /// <returns>Retorna a view de edição ou NotFound se não existir.</returns>
        public IActionResult Alterar(int itemId)
        {
            // Busca o usuário na listagem pelo ID
            var usuario = Usuario.Listagem.First(u => u.Id == itemId);
            // Se o usuário não existir, retorna NotFound
            if (usuario == null)
            {
                return NotFound();
            }

            // Retorna a view de edição passando o usuário encontrado
            return View(usuario);
        }

        /// <summary>
        /// Processa o envio do formulário de alteração de usuário (requisição POST).
        /// </summary>
        /// <param name="usuario">Objeto Usuario preenchido pelo formulário.</param>
        /// <returns>Redireciona para a lista de usuários se válido, senão retorna a view de edição.</returns>
        [HttpPost]
        public IActionResult Alterar(Usuario usuario)
        {
            // Verifica se o modelo recebido é válido
            if (ModelState.IsValid)
            {
                // Salva as alterações do usuário utilizando o método estático Salvar
                Usuario.Salvar(usuario);
                // Redireciona para a ação Usuarios após a alteração
                return RedirectToAction("Usuarios");
            }

            // Se o modelo não for válido, retorna à view de edição com os dados preenchidos
            return View(usuario);
        }

        /// <summary>
        /// Exibe a lista de usuários cadastrados.
        /// </summary>
        /// <returns>Retorna a view com a listagem de usuários.</returns>
        public IActionResult Usuarios()
        {
            // Retorna a view passando a lista de usuários cadastrados
            return View(Usuario.Listagem);
        }
    }
}