using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shirts.Models.Repositories;

namespace Shirts.Filters
{
	public class Shirt_ValidateShirtIdFilterAttribute : ActionFilterAttribute 
	{
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var ShirtId = context.ActionArguments["id"] as int?;
            if(ShirtId.HasValue)
            {
                if (ShirtId <= 0)
                {
                    context.ModelState.AddModelError("ShirtId", "ShirtId is invalid.");
                    var problem_state = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problem_state);

                }
                else if (!ShirtRepository.ShirtExists(ShirtId.Value))
                {
                    context.ModelState.AddModelError("ShirtId", "Shirt doesn't exist.");
                    var problem_state = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new NotFoundObjectResult(problem_state);
                }
            }
        }
    }
}

