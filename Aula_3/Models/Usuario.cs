namespace Aula_3.Models
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