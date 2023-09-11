using Microsoft.AspNetCore.Mvc;
using Shirts.Data;
using Shirts.Filters.ActionFilters;
using Shirts.Filters.ExceptionFilters;
using Shirts.Models;
using Shirts.Models.Repositories;

namespace Shirts.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        // DI of the DbContext
        public ShirtsController(ApplicationDbContext db)
        {
            this.db = db;
        }


        [HttpGet]
        public IActionResult GetShirts()
        {
            return Ok(db.Shirts.ToList());
        }
        
        [HttpGet("{id}")]
        // ActionFilter invoked before action for validation id.
        // Now with DI of DbContext
        [TypeFilter(typeof(Shirt_ValidateShirtIdFilterAttribute))] 
        public IActionResult GetShirtById(int id)
        {
            
            return Ok(HttpContext.Items["shirt"]);
        }

        [HttpPost]
        // ActionFilter invoked before action for validation shirt.
        [TypeFilter(typeof(Shirt_ValidateCreateShirtFilterAttribute))]
        public IActionResult CreateShirts([FromBody] Shirt shirt)
        {
            //if (shirt == null) { return BadRequest(); }
            //var existingShirt = ShirtRepository.GetShirtByProperties(shirt.Brand, shirt.Gender, shirt.Color, shirt.Size);
            //if (existingShirt != null) { return BadRequest(); };

            this.db.Shirts.Add(shirt);
            this.db.SaveChanges();

            return CreatedAtAction(nameof(GetShirtById),
                new { id = shirt.ShirtId }, shirt);
        }

        [HttpPut("{id}")]
        // ActionFilter validation id
        //// Now with DI of DbContext
        [TypeFilter(typeof(Shirt_ValidateShirtIdFilterAttribute))]
        // ActionFilter for validation ShirtId with id
        [Shirt_ValedateUpdateShirtFilter]
        // ExceptionFilter
        [TypeFilter(typeof(Shirt_HandleUpdateExceptionsFilterAttribute))]
        public IActionResult UpdateShirts(int id, Shirt shirt)
        {

            var updateShirt = HttpContext.Items["shirt"] as Shirt;
            updateShirt.Brand = shirt.Brand;
            updateShirt.Color = shirt.Color;
            updateShirt.Gender = shirt.Gender;
            updateShirt.Price = shirt.Price;
            updateShirt.Size = shirt.Size;

            db.SaveChanges();

            return NoContent(); 
        }

        [HttpDelete("{id}")]
        //// Now with DI of DbContext
        [TypeFilter(typeof(Shirt_ValidateShirtIdFilterAttribute))]
        public IActionResult DeleteShirts(int id)
        {
            var DeleteShirt = HttpContext.Items["shirt"] as Shirt;
            db.Shirts.Remove(DeleteShirt);
            db.SaveChanges();
            return Ok(DeleteShirt);
        }
    }
}
