
using BookStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookStoreAPI.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var error = new ErrorModel
        {
            Status = "500",
            Message = context.Exception.Message
        };

        context.Result = new JsonResult(error) { StatusCode = 500 };
    }
}