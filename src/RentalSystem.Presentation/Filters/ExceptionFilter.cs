using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RentalSystem.Communication.Responses;
using RentalSystem.Exceptions.ExceptionBase;

namespace RentalSystem.Presentation.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is RentalSystemException rentalSystemException) 
                HandleProjectException(rentalSystemException, context);
            else 
                ThrowUnknowException(context);
        }

        private static void HandleProjectException(RentalSystemException rentalSystemException, ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)rentalSystemException.GetStatusCode();
            context.Result = new ObjectResult(new ResponseErrorJson(rentalSystemException.GetErrorMessage()));
        }

        private static void ThrowUnknowException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new ObjectResult(new ResponseErrorJson(context.Exception.Message));
        }
    }
}
