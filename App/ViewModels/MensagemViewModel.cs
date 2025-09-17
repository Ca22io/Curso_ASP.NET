using Newtonsoft.Json;

namespace App.ViewModels
{
    public enum TipoMensagem
    {
        Erro,
        Informacao
    }

    public class MensagemViewModel
    {
        public string Texto { get; set; }
        public TipoMensagem Tipo { get; set; }

        public MensagemViewModel(string mensagem, TipoMensagem tipo = TipoMensagem.Informacao)
        {
            this.Texto = mensagem;
            this.Tipo = tipo;
        }

        public static string Serializar(string mensagem, TipoMensagem tipo = TipoMensagem.Informacao)
        {
            var mensagemModel = new MensagemViewModel(mensagem, tipo);
            return JsonConvert.SerializeObject(mensagemModel);
        }
        
        public static MensagemViewModel Deserializar(string mensagemString)
        {
            return JsonConvert.DeserializeObject<MensagemViewModel>(mensagemString);
        }
    }
}