using Microsoft.EntityFrameworkCore;

namespace EstoqueWeb.Models
{
    public class EstoqueWebContext : DbContext
    {
        public DbSet<CategoriaModel> Categorias { get; set; }

        public EstoqueWebContext(DbContextOptions<EstoqueWebContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaModel>().ToTable("Categoria");
        }
    }
}