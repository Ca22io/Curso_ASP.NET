// Define o namespace do projeto, agrupando as classes relacionadas
namespace Aula_4.Models
{
    // Define a classe Usuario, que representa um usuário do sistema
    public class Usuario
    {
        // Propriedade que armazena o identificador único do usuário
        public int Id { get; set; }

        // Propriedade que armazena o nome do usuário (pode ser nulo)
        public string? Nome { get; set; }

        // Propriedade que armazena o e-mail do usuário (pode ser nulo)
        public string? Email { get; set; }

        // Lista estática privada que armazena todos os usuários em memória
        private static List<Usuario> listagem = new List<Usuario>();

        // Propriedade estática que expõe a lista de usuários como IQueryable (apenas leitura)
        public static IQueryable<Usuario> Listagem
        {
            get
            {
                // Retorna a lista de usuários como IQueryable para permitir consultas LINQ
                return listagem.AsQueryable();
            }
        }

        // Método estático para salvar (adicionar ou atualizar) um usuário na lista
        public static void Salvar(Usuario usuario)
        {
            // Procura um usuário existente na lista com o mesmo Id
            var existingUsuario = Usuario.listagem.Find(u => u.Id == usuario.Id);

            if (existingUsuario != null)
            {
                // Se encontrado, atualiza o nome e o e-mail do usuário existente
                existingUsuario.Nome = usuario.Nome;
                existingUsuario.Email = usuario.Email;
            }
            else
            {
                // Se não encontrado, obtém o maior Id existente na lista
                int maiorId = listagem.Max(u => u.Id);

                // Atribui ao novo usuário um Id incrementado
                usuario.Id = maiorId + 1;

                // Adiciona o novo usuário à lista
                Usuario.listagem.Add(usuario);
            }
        }

        // Método estático para excluir um usuário da lista pelo Id
        public static void Excluir(int id)
        {
            // Procura o usuário com o Id informado
            var usuario = listagem.FirstOrDefault(u => u.Id == id);

            if (usuario != null)
            {
                // Se encontrado, remove o usuário da lista
                listagem.Remove(usuario);
            }
        }

        // Construtor estático da classe Usuario, executado uma vez ao acessar a classe
        static Usuario()
        {
            // Adiciona alguns usuários de exemplo à lista ao iniciar a aplicação
            Usuario.listagem.Add(new Usuario { Id = 1, Nome = "João", Email = "joao@email.com" });
            Usuario.listagem.Add(new Usuario { Id = 2, Nome = "Maria", Email = "maria@email.com" });
            Usuario.listagem.Add(new Usuario { Id = 3, Nome = "Carlos", Email = "carlos@email.com" });
            Usuario.listagem.Add(new Usuario { Id = 4, Nome = "Ana", Email = "ana@email.com" });
            Usuario.listagem.Add(new Usuario { Id = 5, Nome = "Pedro", Email = "pedro@email.com" });
            Usuario.listagem.Add(new Usuario { Id = 6, Nome = "Fernanda", Email = "fernanda@email.com" });
        }
    }
}