using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public IActionResult GetShirts()
        {
            return Ok(ShirtRepository.GetShirts());
        }
        
        [HttpGet("{id}")]
        // ActionFilter invoked before action for validation id.
        [Shirt_ValidateShirtIdFilter] 
        public IActionResult GetShirtById(int id)
        {
            
            return Ok(ShirtRepository.GetShirtById(id));
        }

        [HttpPost]
        // ActionFilter invoked before action for validation shirt.
        [Shirt_ValidateCreateShirtFilter]
        public IActionResult CreateShirts([FromBody] Shirt shirt)
        {
            //if (shirt == null) { return BadRequest(); }
            //var existingShirt = ShirtRepository.GetShirtByProperties(shirt.Brand, shirt.Gender, shirt.Color, shirt.Size);
            //if (existingShirt != null) { return BadRequest(); };

            ShirtRepository.CreateShirts(shirt);


            return CreatedAtAction(nameof(GetShirtById),
                new { id = shirt.ShirtId }, shirt);
        }

        [HttpPut("{id}")]
        // ActionFilter validation id
        [Shirt_ValidateShirtIdFilter]
        // ActionFilter for validation ShirtId with id
        [Shirt_ValedateUpdateShirtFilter]
        // ExceptionFilter
        [Shirt_HandleUpdateExceptionsFilter]
        public IActionResult UpdateShirts(int id, Shirt shirt)
        {
            
            ShirtRepository.UpdateShirt(shirt);
            

            return NoContent(); 
        }

        [HttpDelete("{id}")]
        [Shirt_ValidateShirtIdFilter]
        public IActionResult DeleteShirts(int id)
        {
            var shirt = ShirtRepository.GetShirtById(id);
            ShirtRepository.DeleteShirt(id);
            return Ok(shirt);
        }
    }
}
