using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace TaskManager.Api.Exceptions
{
    public class ErrorHandlingFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            string message = Errors.ServerError;

            if (context.Exception is ApiException apiException)
            {
                status = apiException.StatusCode;
                message = apiException.Message;
            }
            else if (context.Exception is ArgumentException)
            {
                status = HttpStatusCode.BadRequest;
                message = context.Exception.Message;
            }

            context.Result = new JsonResult(new ErrorResponse(message))
            {
                StatusCode = (int)status
            };

            context.ExceptionHandled = true;
        }
    }
}
