namespace RentalSystem.Communication.Responses
{
    public class ResponseErrorJson
    {
        public string Mensagem { get; set; }

        public ResponseErrorJson(string errorMessage) => Mensagem = errorMessage;
        

    }
}
