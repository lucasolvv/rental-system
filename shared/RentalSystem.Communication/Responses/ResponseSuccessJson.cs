namespace RentalSystem.Communication.Responses
{
    public class ResponseSuccessJson
    {
        public string Mensagem { get; set; }
        public ResponseSuccessJson(string mensagem) => Mensagem = mensagem;

    }
}
