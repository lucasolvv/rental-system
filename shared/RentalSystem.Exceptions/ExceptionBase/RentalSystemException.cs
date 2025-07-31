using System.Net;

namespace RentalSystem.Exceptions.ExceptionBase
{
    public abstract class RentalSystemException : SystemException
    {
        protected RentalSystemException(string message) : base(message) { }

        public abstract string GetErrorMessage();
        public abstract HttpStatusCode GetStatusCode();
    }
}
