namespace Aula_2.Models
{
    static class Repositorio
    {
        private static List<Resposta> respostas = new List<Resposta>();

        public static IEnumerable<Resposta> Respostas
        {
            get { return respostas; }
        }

        public static void AdicionarResposta(Resposta reposta)
        {
            respostas.Add(reposta);
        }
    }
}
