using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shirts.Models.Repositories;

namespace Shirts.Filters.ExceptionFilters
{
	public class Shirt_HandleUpdateExceptionsFilterAttribute : ExceptionFilterAttribute
	{
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var strShirtId = context.RouteData.Values["id"] as string;
            if(int.TryParse(strShirtId, out int shirtId))
            {
                if (!ShirtRepository.ShirtExists(shirtId))
                {
                    context.ModelState.AddModelError("shirtId", "ShirtId doesn't excist anymore.");
                    var problem_state = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problem_state);
                }
            }
        }

    }
}

