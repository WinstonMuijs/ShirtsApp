using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shirts.Data;
using Shirts.Models.Repositories;

namespace Shirts.Filters.ActionFilters
{
	public class Shirt_ValidateShirtIdFilterAttribute : ActionFilterAttribute
	{
        private readonly ApplicationDbContext db;

        public Shirt_ValidateShirtIdFilterAttribute(ApplicationDbContext db)
        {
            this.db = db;

        }
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
                else 
                {
                    // this shirt
                    var shirt = db.Shirts.Find(ShirtId.Value);

                    if(shirt == null)
                    {
                        context.ModelState.AddModelError("ShirtId", "Shirt doesn't exist.");
                        var problem_state = new ValidationProblemDetails(context.ModelState)
                        {
                            Status = StatusCodes.Status404NotFound
                        };
                        context.Result = new NotFoundObjectResult(problem_state);
                    }
                    else // this shirt from filter to controller
                    {
                        // HttpContext slaat dan shirt op
                        context.HttpContext.Items["shirt"] = shirt;
                    }

                   
                }
            }
        }
    }
}

