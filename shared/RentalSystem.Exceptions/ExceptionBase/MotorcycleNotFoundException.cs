namespace RentalSystem.Exceptions.ExceptionBase
{
    public class MotorcycleNotFoundException : RentalSystemException
    {
        private readonly string _errorMessage;
        public MotorcycleNotFoundException(string errorMessage) : base(string.Empty)
        {
            _errorMessage = errorMessage;
        }
        public override string GetErrorMessage() => _errorMessage;
        public override System.Net.HttpStatusCode GetStatusCode() => System.Net.HttpStatusCode.NotFound;
    }
}
