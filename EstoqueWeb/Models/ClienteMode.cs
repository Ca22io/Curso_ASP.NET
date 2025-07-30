using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstoqueWeb.Models
{
    public class ClienteModel : UsuarioModel
    {

        [Required, Column(TypeName = "char(14)")]
        public string CPF { get; set; }

        public DateTime DataNascimento { get; set; }

        [NotMapped]
        public int Idade
        {
            get => (int)Math.Floor(DateTime.Now.Subtract(DataNascimento).TotalDays / 365.2425);
            // {
            //     int dias = DateTime.Now.Subtract(DataNascimento).Days;
            //     int anos = (int)Math.Floor(dias / 365.2425);
            //     return anos;
            // }
        }

        public EnderecoModel Endereco { get; set; }

    }
}
