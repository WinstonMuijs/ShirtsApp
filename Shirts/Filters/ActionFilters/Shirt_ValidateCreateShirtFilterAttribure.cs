using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Policy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shirts.Data;
using Shirts.Models;
using Shirts.Models.Repositories;

namespace Shirts.Filters.ActionFilters
{
	public class Shirt_ValidateCreateShirtFilterAttribute : ActionFilterAttribute
	{
        private readonly ApplicationDbContext db;

        public Shirt_ValidateCreateShirtFilterAttribute(ApplicationDbContext db)
        {
            this.db = db;
        }
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
                 var existingShirt = db.Shirts.FirstOrDefault(x =>
                    !string.IsNullOrWhiteSpace(shirt.Brand) &&
                    !string.IsNullOrWhiteSpace(x.Brand) &&
                    x.Brand.ToLower() == shirt.Brand.ToLower() &&
                    !string.IsNullOrWhiteSpace(shirt.Gender) &&
                    !string.IsNullOrWhiteSpace(x.Gender) &&
                    x.Gender.ToLower() == shirt.Gender.ToLower() &&
                    !string.IsNullOrWhiteSpace(shirt.Color) &&
                    !string.IsNullOrWhiteSpace(x.Color) &&
                    x.Color.ToLower() == shirt.Color.ToLower() &&
                    shirt.Size.HasValue &&
                    x.Size.HasValue &&
                    shirt.Size.Value == x.Size.Value);

                
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
