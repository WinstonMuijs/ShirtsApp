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
            return Ok("Get All the shirts from the e-shop");
        }
        
        [HttpGet("{id}")]
        [Shirt_ValidateShirtIdFilter] // Filter invoked before action.
        public IActionResult GetShirts(int id)
        {
            
            return Ok(ShirtRepository.GetShirtById(id));
        }
        
        [HttpPost]
        public IActionResult CreateShirts([FromBody] Shirt shirt)
        {
            return Ok("Post a shirt from the e-shop");
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
