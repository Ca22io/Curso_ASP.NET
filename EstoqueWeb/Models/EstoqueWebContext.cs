using Microsoft.EntityFrameworkCore;

namespace EstoqueWeb.Models
{
    public class EstoqueWebContext : DbContext
    {
        public DbSet<CategoriaModel> Categorias { get; set; }

        public DbSet<ProdutoModel> Produtos { get; set; }

        public DbSet<ClienteModel> Clientes { get; set; }

        public EstoqueWebContext(DbContextOptions<EstoqueWebContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaModel>().ToTable("Categoria");
            modelBuilder.Entity<ProdutoModel>().ToTable("Produto");
        }
    }
}