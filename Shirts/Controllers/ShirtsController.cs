using Microsoft.AspNetCore.Mvc;
using Shirts.Filters;
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
        [Shirt_ValidateShirtIdFilter] // Filter invoked before action.
        public IActionResult GetShirtById(int id)
        {
            
            return Ok(ShirtRepository.GetShirtById(id));
        }

        [HttpPost]
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
        public IActionResult UpdateShirts(int id)
        {
            return Ok($"Update a shirt from the e-shop with id: {id}");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShirts(int id)
        {
            return Ok($"Delete ashirts from the e-shop with id: {id}");
        }
    }
}
