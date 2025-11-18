using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PassIn.Communication.Responses;
using PassIn.Exceptions;

namespace PassIn.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is PassInException) 
            HandleProjectException(context);
        else 
            ThrowUnknownError(context);
    }

    private void ThrowUnknownError(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorJson("Unknown error"));

    }

    private void HandleProjectException(ExceptionContext context)
    {

        if (context.Exception is NotFoundException)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            context.Result = new NotFoundObjectResult(new ResponseErrorJson(context.Exception.Message));
        }
            
    }
}