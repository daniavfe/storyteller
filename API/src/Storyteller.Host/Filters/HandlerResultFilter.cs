using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Storyteller.Application.Validation;

namespace Storyteller.Host.Filters
{
    public class HandlerResultFilter : IActionFilter
    {

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var handlerResult = (HandlerResult)((ObjectResult)context.Result).Value;
   

            if (handlerResult.IsFailure)
            {
                context.Result = new BadRequestObjectResult(handlerResult.Error);
                return;
            }

            if (handlerResult.Value != null)
            {
                context.Result = new OkObjectResult(handlerResult.Value);
                return;
            }

            context.Result = new NoContentResult();
            return;

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }

    }
}
