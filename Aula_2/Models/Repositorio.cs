namespace Aula_2.Models
{
    // Classe estática que serve como repositório de respostas
    static class Repositorio
    {
        // Lista estática privada para armazenar objetos do tipo Resposta
        private static List<Resposta> respostas = new List<Resposta>();

        // Propriedade somente leitura que expõe as respostas armazenadas
        public static IEnumerable<Resposta> Respostas
        {
            get { return respostas; } // Retorna a lista de respostas
        }

        // Método estático para adicionar uma nova resposta ao repositório
        public static void AdicionarResposta(Resposta reposta)
        {
            respostas.Add(reposta); // Adiciona a resposta recebida à lista
        }
    }
}
