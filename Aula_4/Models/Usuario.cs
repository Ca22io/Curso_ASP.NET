namespace Aula_4.Models
{
    public class Usuario
    {
        public int Id { get; set; }
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
        
        public static void Adicionar(Usuario usuario)
        {
            if (usuario != null)
            {
                usuario.Id = listagem.Count + 1; // Simples incremento para ID
                listagem.Add(usuario);
            }
        }
        
        public static void Alterar(Usuario usuario)
        {
            var existingUsuario = listagem.FirstOrDefault(u => u.Id == usuario.Id);
            if (existingUsuario != null)
            {
                existingUsuario.Nome = usuario.Nome;
                existingUsuario.Email = usuario.Email;
            }
        }

        public static void Excluir(int id)
        {
            var usuario = listagem.FirstOrDefault(u => u.Id == id);

            if (usuario != null)
            {
                listagem.Remove(usuario);
            }
        }


        static Usuario()
        {
            // Adicionando alguns usuários de exemplo
            Usuario.listagem.Add(new Usuario { Id = 1, Nome = "João", Email = "joao@email.com" });
            Usuario.listagem.Add(new Usuario { Id = 2, Nome = "Maria", Email = "maria@email.com" });
            Usuario.listagem.Add(new Usuario { Id = 3, Nome = "Carlos", Email = "carlos@email.com" });
            Usuario.listagem.Add(new Usuario { Id = 4, Nome = "Ana", Email = "ana@email.com" });
            Usuario.listagem.Add(new Usuario { Id = 5, Nome = "Pedro", Email = "pedro@email.com" });
            Usuario.listagem.Add(new Usuario { Id = 6, Nome = "Fernanda", Email = "fernanda@email.com" });
        }
        
    }
}