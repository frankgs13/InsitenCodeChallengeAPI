using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;
using System.Linq;

namespace Insiten.Code.Challenge.API.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // TO DO:
            //  You can save here the error information in a log.

            context.Result = new ObjectResult(context.Exception.InnerException) { StatusCode = 500 };
        }
    }
}
