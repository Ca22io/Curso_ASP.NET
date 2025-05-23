using System.ComponentModel.DataAnnotations;

namespace Aula_2.Models
{
    public class Resposta
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "A resposta é obrigatória.")]
        public bool? Sim { get; set; }
        
    }
}