namespace Aula_3.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }

        private static List<Usuario> listagem = new List<Usuario>();

        public static IQueryable<Usuario> Listagem
        {
            get
            {
                return listagem.AsQueryable();
            }
        }

        static Usuario()
        {
            // Adicionando alguns usuários de exemplo
            Usuario.listagem.Add(new Usuario { IdUsuario = 1, Nome = "João", Email = "joao@email.com" });
            Usuario.listagem.Add(new Usuario { IdUsuario = 2, Nome = "Maria", Email = "maria@email.com" });
            Usuario.listagem.Add(new Usuario { IdUsuario = 3, Nome = "Carlos", Email = "carlos@email.com" });
            Usuario.listagem.Add(new Usuario { IdUsuario = 4, Nome = "Ana", Email = "ana@email.com" });
            Usuario.listagem.Add(new Usuario { IdUsuario = 5, Nome = "Pedro", Email = "pedro@email.com" });
            Usuario.listagem.Add(new Usuario { IdUsuario = 6, Nome = "Fernanda", Email = "fernanda@email.com" });
        }

        public static void Salvar(Usuario usuario)
        {
            var usuarioExistente = Usuario.listagem.Find(u => u.IdUsuario == usuario.IdUsuario);
            if (usuarioExistente != null)
            {
                usuarioExistente.Nome = usuario.Nome;
                usuarioExistente.Email = usuario.Email;
            }
            else
            {
                int maiorId = Usuario.Listagem.Max(u => u.IdUsuario);
                usuario.IdUsuario = maiorId + 1;
                Usuario.listagem.Add(usuario);
            }
        }

        public static bool Excluir(int idUsuario)
        {
            var usuarioExistente = Usuario.listagem.Find(u => u.IdUsuario == idUsuario);
            if (usuarioExistente != null)
            {
                return Usuario.listagem.Remove(usuarioExistente);
            }
            return false;
        }

    
    }
}