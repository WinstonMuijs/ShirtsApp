using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shirts.Models;
using Shirts.Models.Repositories;

namespace Shirts.Filters.ActionFilters
{
	public class Shirt_ValidateCreateShirtFilterAttribute : ActionFilterAttribute
	{
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            

            var shirt = context.ActionArguments["shirt"] as Shirt;
            if(shirt == null)
            {
                context.ModelState.AddModelError("shirt", "shirt object is null.");
                var problem_state = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problem_state);
            }
            else 
            {
                var existingShirt = ShirtRepository.GetShirtByProperties(shirt.Brand, shirt.Gender, shirt.Color, shirt.Size);
                if (existingShirt != null)
                {


                    context.ModelState.AddModelError("Shirt", "Shirt object allready exist.");
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
