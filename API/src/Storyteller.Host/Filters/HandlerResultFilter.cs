using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Storyteller.Application.Validation;

namespace Storyteller.Host.Filters
{
    public class HandlerResultFilter : IActionFilter
    {

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var con = (HandlerResult)((ObjectResult)context.Result).Value;

            if (con.IsFailure)
            {
                context.Result = new BadRequestObjectResult(con.Error);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }

    }
}
