using System.ComponentModel.DataAnnotations;

namespace EstoqueWeb.Models
{
    public class CategoriaModel
    {
        [Key]
        public int IdCategoria { get; set; }

        [Required, MaxLength(128)]
        public required string Nome { get; set; }
    }
}