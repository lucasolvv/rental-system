using System.Net;

namespace RentalSystem.Exceptions.ExceptionBase;
public class ErrorOnValidationException : RentalSystemException
{
    private readonly string _errorMessage;

    public ErrorOnValidationException(string errorMessage) : base(string.Empty)
    {
        _errorMessage = errorMessage;
    }

    public override string GetErrorMessage() => _errorMessage;

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
}