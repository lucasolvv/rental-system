namespace RentalSystem.Exceptions.ExceptionBase
{
    public class MotorcycleNotFoundException : RentalSystemException
    {
        public string Mensagem { get; set; }
        public MotorcycleNotFoundException(string mensagem) : base(string.Empty)
        {
            Mensagem = mensagem;
        }
        public override string GetErrorMessage() => Mensagem;
        public override System.Net.HttpStatusCode GetStatusCode() => System.Net.HttpStatusCode.NotFound;
    }
}
