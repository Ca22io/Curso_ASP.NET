using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstoqueWeb.Models
{
    public class ProdutoModel
    {
        [Key]
        public int IdProduto { get; set; }

        [Required, MaxLength(100)]
        public string Nome { get; set; }

        public double Preco { get; set; }

        public int Estoque { get; set; }

        [ForeignKey("Categoria")]
        public int IdCategoria { get; set; }

        public CategoriaModel? Categoria { get; set; }
    }
}