

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace StoreBox.Controller
{
    public class ValidationFilterAttribute : ActionFilterAttribute, IActionFilter
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var order = context.ActionArguments;
            if (order == null)
            {
                context.Result = new BadRequestObjectResult("Order is null");
                return;
            }

            if (!context.ModelState.IsValid)
            {
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
            }
        }
    }
}
