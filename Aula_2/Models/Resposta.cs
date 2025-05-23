using System.ComponentModel.DataAnnotations; // Importa atributos para validação de dados

namespace Aula_2.Models // Define o namespace do projeto, agrupando classes relacionadas
{
    // Define a classe Resposta, que representa um modelo de dados (por exemplo, para um formulário)
    public class Resposta
    {
        // O atributo [Required] indica que o campo é obrigatório.
        // ErrorMessage define a mensagem exibida se o campo não for preenchido.
        // 'required' (C# 11+) obriga a inicialização da propriedade ao criar o objeto.
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public required string Nome { get; set; }

        // Mesmo conceito do campo acima, mas para o email.
        [Required(ErrorMessage = "O email é obrigatório.")]
        public required string Email { get; set; }

        // Campo obrigatório, mas do tipo bool? (booleano anulável).
        // Isso permite três estados: true, false ou null (não respondido).
        // Útil para perguntas de sim/não onde o usuário pode não responder.
        [Required(ErrorMessage = "A resposta é obrigatória.")]
        public bool? Sim { get; set; }
        // Dica: O [Required] em tipos anuláveis (como bool?) garante que o valor não seja null.
        // Se fosse apenas bool, o valor padrão seria false, dificultando saber se o usuário respondeu.
    }
}