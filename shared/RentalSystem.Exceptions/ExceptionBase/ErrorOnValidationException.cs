using System.Net;

namespace RentalSystem.Exceptions.ExceptionBase;
public class ErrorOnValidationException : RentalSystemException
{
    private readonly string Mensagem;

    public ErrorOnValidationException(string errorMessage) : base(string.Empty)
    {
        Mensagem = errorMessage;
    }

    public override string GetErrorMessage() => Mensagem;

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
}